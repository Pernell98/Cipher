# Cipher

## Cipher application that generates a key through string inputs via Message-Digest Algorithm 5 that also decrypts same said generated key. 
<img src="Cipher Gif.gif" alt="Cipher" width="1000" height="400" class="center"/>


## Description

The input string is converted to a byte array where it is then hashed into an array of 16 bytes where the methods are then formated to return hexadecimal values. This is to better interoperate with Message-Digest Algorithm 5. Lastly, the key is and stores the value, where it is then transformed and encrypted. The decryptor converts the encrypted string via Message-Digest Algorithm 5 then transforms the value back to its original input, returning the decrypted key to be utilized.
