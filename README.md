# Demo Api
A simple demo api for my [clean-spa-architecture](https://github.com/diffy0712/clean-spa-architecture) repository.

The app will serve a Rest API to manage products and tags.

## How to start the api server

### Start the environment servers (db, adminer)
In the solution folder there is a makefile to help start the docker environment for the project.

```shell
$ make start
```

This will start the `postgres db` at port `5432` and `adminer` at port `8080`.

To stop use:
```shell
$ make stop
```

### Start the web api server

In the `Api` folder there is a makefile to help start the dotnet server.

```shell
$ make run
```

