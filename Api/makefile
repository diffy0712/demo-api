## dotnet commands

.PHONY: run
run: ## Run dotnet
	dotnet run

.PHONY: mig
mig: ## Migrate entity framework database
	dotnet ef database update

.PHONY: cmig
cmig: ## create migration, make cmig f=initial_migration
	dotnet ef migrations add ${f}

.PHONY: help
help: ## Display this help message
	@cat $(MAKEFILE_LIST) | grep -e "^[a-zA-Z_\-]*: *.*## *" | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'