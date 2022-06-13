compose=docker-compose
export compose

.PHONY: start
start: stop build up ## stop and start

.PHONY: restart
restart: down start ## clean and start

## Docker-compose commands
.PHONY: down
down: ## stop and delete containers (will remove volumes too! You might want to use `make stop` instead)
	$(compose) down -v --rmi local --remove-orphans

.PHONY: build
build: ## build the images
	$(compose) build

.PHONY: up
up: ## start environment
	$(compose) up -d

.PHONY: stop
stop: ## stop environment
	$(compose) stop

.PHONY: pull
pull: ## pull images
	$(compose) pull

.PHONY: logs
logs: ## display service logs
	$(compose) logs -f ${s}

.PHONY: help
help: ## Display this help message
	@cat $(MAKEFILE_LIST) | grep -e "^[a-zA-Z_\-]*: *.*## *" | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'