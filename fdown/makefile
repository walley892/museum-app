CC= gcc
CFLAGS= -Wall -Wextra -Wpedantic -lcurl
CSRC = fdown.c

all: tests

tests: $(CSRC) fdown_tests.c
	gcc $(CFLAGS) $(CSRC) fdown_tests.c -lcunit -o tests


clean:
	rm -f tests
