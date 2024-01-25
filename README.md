# How to reproduce

1) Execute the following command:
```sh
dotnet build -f net8.0-android -c Release /p:AndroidSigningKeyStore=tailcall.keystore /p:AndroidSigningStorePass=tailcall /p:AndroidSigningKeyAlias=tailcall /p:AndroidSigningKeyPass=tailcall
```

2) Build should fail with the following error
```
error : wrong maximal instruction length of instruction tailcall_membase (expected 255, got 256)
```
