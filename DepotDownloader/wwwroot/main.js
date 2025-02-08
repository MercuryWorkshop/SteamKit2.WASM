console.log("start");
const wasm = await eval(`import("/_framework/dotnet.js")`);
const dotnet = wasm.dotnet;

console.debug("initializing dotnet");
const runtime = await dotnet.withConfig({
  jsThreadBlockingMode: "DangerousAllowBlockingWait",
  pthreadInitialPoolSize: 20,
}).create();
console.log("???");
export function encryptRSA(data, n, e) {
  const modExp = (base, exp, mod) => {
    let result = 1n;
    base = base % mod;
    while (exp > 0n) {
      if (exp % 2n === 1n) {
        result = (result * base) % mod;
      }
      exp = exp >> 1n;
      base = (base * base) % mod;
    }
    return result;
  };
  const pkcs1v15Pad = (messageBytes, n) => {
    const messageLength = messageBytes.length;
    const nBytes = Math.ceil(n.toString(16).length / 2);

    if (messageLength > nBytes - 11) {
      throw new Error("Message too long for RSA encryption");
    }

    const paddingLength = nBytes - messageLength - 3;
    const padding = Array(paddingLength).fill(0xff);

    return BigInt(
      "0x" +
      [
        "00",
        "02",
        ...padding.map((byte) => byte.toString(16).padStart(2, "0")),
        "00",
        ...Array.from(messageBytes).map((byte) =>
          byte.toString(16).padStart(2, "0")
        ),
      ].join("")
    );
  };
  const paddedMessage = pkcs1v15Pad(data, n);
  let int = modExp(paddedMessage, e, n);

  let hex = int.toString(16);
  if (hex.length % 2) {
    hex = "0" + hex;
  }

  // ????
  return new Uint8Array(
    Array.from(hex.match(/.{2}/g) || []).map((byte) => parseInt(byte, 16))
  );
}

function wordArrayToUint8Array(wordarray) {
  var len = wordarray.words.length,
    view = new DataView(new ArrayBuffer(len * 4)),
    i = 0;
  for (; i < len; i++) {
    view.setInt32(i * 4, wordarray.words[i], false);
  }
  return new Uint8Array(view.buffer);
}

let timespentdecrypting = 0;
runtime.setModuleImports("interop.js", {
  decrypt: (key, data, iv) => {
    //
    // var aesEcb = new aesjs.ModeOfOperation.ecb(key);
    // var encrypted = aesEcb.encrypt(data);
    //
    // return encrypted;
    const ivEncryptedWordArray = CryptoJS.lib.WordArray.create(data);
    const keyWordArray = CryptoJS.lib.WordArray.create(key);

    // Decrypt the IV using AES-ECB with no padding
    const decryptedIV = CryptoJS.AES.decrypt(
      { ciphertext: ivEncryptedWordArray },
      keyWordArray,
      {
        mode: CryptoJS.mode.ECB,
        padding: CryptoJS.pad.NoPadding
      }
    );

    return wordArrayToUint8Array(decryptedIV);
  },
  decryptcbc: (key, data, iv) => {
    const cbcDataWordArray = CryptoJS.lib.WordArray.create(data);
    const keyWordArray = CryptoJS.lib.WordArray.create(key);
    const ivWordArray = CryptoJS.lib.WordArray.create(iv);
    const decryptedData = CryptoJS.AES.decrypt(
      { ciphertext: cbcDataWordArray },
      keyWordArray,
      {
        iv: ivWordArray,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
      }
    );
    let arr = wordArrayToUint8Array(decryptedData);

    const paddingLength = arr[arr.length - 1];
    arr = arr.slice(0, arr.length - paddingLength);
    if (arr[arr.length - 1] == 0) {
      arr = arr.slice(0, arr.length - 1);
    }
    return arr;
    // var aesCbc = new aesjs.ModeOfOperation.cbc(key, iv);
    // var decrypted = aesCbc.decrypt(data);
    //
    // return decrypted;
  },
  decryptcbc2: (key, data, iv) => {

    let first = performance.now();
    const cbcDataWordArray = CryptoJS.lib.WordArray.create(data);
    const keyWordArray = CryptoJS.lib.WordArray.create(key);
    const ivWordArray = CryptoJS.lib.WordArray.create(iv);
    const decryptedData = CryptoJS.AES.decrypt(
      { ciphertext: cbcDataWordArray },
      keyWordArray,
      {
        iv: ivWordArray,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
      }
    );
    const arr = wordArrayToUint8Array(decryptedData);
    const lastByte = arr[arr.length - 1];
    const paddingLength = lastByte;

    timespentdecrypting += performance.now() - first;

    return arr.slice(0, arr.length - paddingLength);
  },
  encryptrsa: (publicKeyModulusHex, publicKeyExponentHex, data) => {
    console.log(publicKeyModulusHex, publicKeyExponentHex, data);

    let modulus = BigInt("0x" + publicKeyModulusHex);
    let exponent = BigInt("0x" + publicKeyExponentHex);
    let encrypted = encryptRSA(data, modulus, exponent);
    return new Uint8Array(encrypted);
  }
}
)

const config = runtime.getConfig();
const exports = await runtime.getAssemblyExports(config.mainAssemblyName);
const canvas = document.getElementById("canvas");
dotnet.instance.Module.canvas = canvas;

self.wasm = {
  Module: dotnet.instance.Module,
  dotnet,
  runtime,
  config,
  exports,
  canvas,
};

console.log("wasm load");
await libcurl.load_wasm("https://cdn.jsdelivr.net/npm/libcurl.js@0.6.20/libcurl.wasm");
console.log("libcurl  load");
libcurl.set_websocket(`wss://anura.pro/wisp/`);

console.log(await libcurl.fetch("https://google.com"));

window.WebSocket = new Proxy(libcurl.WebSocket, {
  construct(t, a, n) {
    let r = Reflect.construct(t, a, n);

    // r.addEventListener("message", (e) => {
    //   console.log("WS MESSAGE", e.data);
    // });
    // r.addEventListener("open", (e) => {
    //   console.log("WS OPEN", e);
    // });
    // r.addEventListener("close", (e) => {
    //   console.log("WS CLOSE", e);
    // });
    return r;
    // let i = 0;
    // return new Proxy(r, {
    //   get(t, k, x) {
    //     if (k === "send") {
    //       return async function(data) {
    //         console.log("SEND", data, i);
    //         // i++
    //         if (i == 2) {
    //           console.log("oveerwriting");
    //           return t.send(
    //             Uint8Array.from("4c 26 00 80 33 00 00 00 51 01 00 60 87 f5 5c 02 00 62 28 41 75 74 68 65 6e 74 69 63 61 74 69 6f 6e 2e 47 65 74 50 61 73 73 77 6f 72 64 52 53 41 50 75 62 6c 69 63 4b 65 79 23 31 0a 0f 43 6f 6f 6c 45 6c 65 63 74 72 6f 6e 69 63 73".split(" ").map(a => parseInt(a, 16)))
    //           );
    //         } else {
    //           t.send(data);
    //         }
    //       }
    //     }
    //
    //     let f = Reflect.get(t, k, x);
    //     if (typeof f === "function") {
    //       return f.bind(t);
    //     }
    //     return f;
    //   }
    // });
  }
})
let origfetch = window.fetch;
window.fetch = async (...args) => {

  let res;
  // try {
  //   res = await origfetch(...args);
  // } catch {
  res = await libcurl.fetch(...args);
  // }
  return res;
}

console.debug("PreInit...");
await exports.DepotDownloader.Program.PreInit();
console.debug("dotnet initialized");

console.debug("Init...");
await runtime.runMain();

//
// console.debug("MainLoop...");
// const main = () => {
// 	const ret = exports.Program.MainLoop();
//
// 	if (!ret) {
// 		console.debug("Cleanup...");
// 		exports.Program.Cleanup();
// 		return;
// 	}
//
// 	requestAnimationFrame(main);
// }
// requestAnimationFrame(main);
