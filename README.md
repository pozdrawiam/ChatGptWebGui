# ChatGptWebGui

Web frontend for OpenAi ChatGPT.
Chat conversations by own api key.

Cost based on usage, which in most cases is cheaper than a regular ChatGPT subscription.

Crated with Blazor WebAssembly.

## Features

- Chat conversations using OpenAI
- Chats history saving in browser storage

## Dependencies

- .Net 8
- OpenAI api

## Run from source
```sh
dotnet run --project Cwg.WebGui
```

## Publish
```sh
dotnet publish Cwg.WebGui -c Release
```

## Using

Before chat set api key in settings page.

## Todo

- use bootstrap css framework for responsive ui
- better error handling
- dark mode
- cancelation
- data by stream
- tests
