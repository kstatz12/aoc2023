HOST_TARGET = src/AOC2023.ConsoleHost/AOC2023.ConsoleHost.csproj
PROJECT_TARGET = src/AOC2023/AOC2023.csproj
TEST_TARGET = src/AOC2023.UnitTests/AOC2023.UnitTests.csproj

all: restore build

restore:
	dotnet restore $(HOST_TARGET)
	dotnet restore $(PROJECT_TARGET)
	dotnet restore $(TEST_TARGET)

clean:
	dotnet clean $(HOST_TARGET)
	dotnet clean $(PROJECT_TARGET)
	dotnet clean $(TEST_TARGET)

build:
	dotnet build $(HOST_TARGET)
	dotnet build $(PROJECT_TARGET)
	dotnet build $(TEST_TARGET)

test:
	dotnet test $(TEST_TARGET)

run:
	dotnet run --project $(HOST_TARGET) -- $(DAY) $(PART) $(INPUT)
