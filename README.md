# How to reproduce

1) Make sure to have dotnet 8.0 installed on your machine
2) Install the Android workload
```sh
dotnet workload restore
```
2) Execute the following command:
```sh
dotnet build -f net8.0-android -c Release /p:AndroidSigningKeyStore=tailcall.keystore /p:AndroidSigningStorePass=tailcall /p:AndroidSigningKeyAlias=tailcall /p:AndroidSigningKeyPass=tailcall
```
3) Build should fail with the following error
```
error : wrong maximal instruction length of instruction tailcall_membase (expected 255, got 256)
```
