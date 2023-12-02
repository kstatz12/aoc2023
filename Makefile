HOST_TARGET = src/AOC2023.ConsoleHost/AOC2023.ConsoleHost.csproj
PROJECT_TARGET = src/AOC2023/AOC2023.csproj
TEST_TARGET = src/AOC2023.UnitTests/AOC2023.UnitTests.csproj

all: build test

build:
	dotnet build $(HOST_TARGET)
	dotnet build $(PROJECT_TARGET)
	dotnet build $(TEST_TARGET)

test:
	dotnet test $(TEST_TARGET)

clean:
	dotnet clean $(HOST_TARGET)
	dotnet clean $(PROJECT_TARGET)
	dotnet clean $(TEST_TARGET)

run: build
	dotnet run --no-build --no-restore --project $(HOST_TARGET) $(DAY) $(PART) $(INPUT)
