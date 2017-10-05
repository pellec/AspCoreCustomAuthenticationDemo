# AspCoreCustomAuthenticationDemo
A quick demo of using custom authentication in asp core 1.1

Issue the following http request in order to access the protected api:

    GET http://localhost:55249/api HTTP/1.1
    Authorization: Custom QWxhZGRpbjpvcGVuIHNlc2FtZQ==

The Authorization header value is '*Aladdin:open sesame*' in Base64 format.
