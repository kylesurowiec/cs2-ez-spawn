.PHONY: build-spawn
build-spawn:
		dotnet build CS2EZSpawn

.PHONY: build-lib
build-lib:
		dotnet build CS2EZSpawn.Lib

.PHONY: build-prod
build-prod:
		dotnet build CS2EZSpawn --configuration Release

.PHONY: test
test:
		dotnet test CS2EZSpawn.Test

