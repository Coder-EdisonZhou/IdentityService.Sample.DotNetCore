# IdentityService.Sample.DotNetCore

## 关于IdentityServer
<img src="https://images2018.cnblogs.com/blog/381412/201806/381412-20180623100819093-778772638.png" width="200" height="210" /><br/>
IdentityServer4（这里只使用版本号为4）是一个基于OpenID Connect和OAuth 2.0的针对ASP.NET Core 2.0的框架。IdentityServer是将规范兼容的OpenID Connect和OAuth 2.0终结点添加到任意ASP.NET Core应用程序的中间件。通常，你构建（或重新使用）包含登录和注销页面的应用程序，IdentityServer中间件会向其添加必要的协议头，以便客户端应用程序可以使用这些标准协议与其对话。<br/>
<img src="https://upload-images.jianshu.io/upload_images/9128511-e6493b64b1caf887.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/700"/><br/>
我们可以用IdentityServer来做啥？

  - 身份验证服务=>官方认证的OpenID Connect实现
  - 单点登录/注销（SSO）
  - 访问受控的API=>为不同的客户提供访问API的令牌，比如：MVC网站、SPA、Mobile App等
  - 等等等......

IdentityServer4 github : https://github.com/IdentityServer/IdentityServer4

## 关于Ocelot
<img src="https://images2018.cnblogs.com/blog/381412/201806/381412-20180611222147722-2104263492.png" width="200" height="240" /><br/>
Ocelot是一个使用.NET Core平台上的一个API Gateway，这个项目的目标是在.NET上面运行微服务架构。Ocelot框架内部集成了IdentityServer（身份验证）和Consul（服务注册发现），还引入了Polly来处理进行故障处理。目前，腾讯和微软是Ocelot在官网贴出来的客户。<br/>
Ocelot github : https://github.com/TomPallister/Ocelot

## 关于此示例项目
<img src="https://images2018.cnblogs.com/blog/381412/201807/381412-20180708201510167-1293314802.png" /><br/>
这里，假设我们有两个客户端（一个Web网站，一个移动App），他们要使用系统，需要通过API网关（这里API网关始终作为客户端的统一入口）先向IdentityService进行Login以进行验证并获取Token，在IdentityService的验证过程中会访问数据库以验证。然后再带上Token通过API网关去访问具体的API Service。这里我们的IdentityService基于IdentityServer4开发，它具有统一登录验证和授权的功能。

必要中间件的安装：<br/>
Ocelot
```sh
PM> Install-Package Ocelot
```
IdentityServer
```sh
PM> Install-Package IdentityServer4
```

## 参考博文
此系列相关参考：<br/>
[基于IdentityServer实现授权与验证服务（Part 1）](https://www.cnblogs.com/edisonchou/p/identityserver4_foundation_and_quickstart_01.html)<br/>
[基于IdentityServer实现授权与验证服务（Part 2）](https://www.cnblogs.com/edisonchou/p/identityserver4_foundation_and_quickstart_02.html)<br/>
[基于Ocelot+IdentityServer实现统一验证与授权服务](https://www.cnblogs.com/edisonchou/p/integration_authentication-authorization_service_foundation.html)<br/>
更多.Net Core相关文章：<br/>
[.NET Core微服务基础学习与实践系列文章目录导航](https://www.cnblogs.com/edisonchou/p/dotnetcore_microservice_foundation_blogs_index.html)
