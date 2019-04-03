CC= gcc
CFLAGS= -Wall -Wextra -Wpedantic -ljpeg -lpng -lm
#CSRC = qr_ed_example.c qr_ed.c qrlib/quirc.c qrlib/decode.c qrlib/dbgutil.c qrlib/identify.c
CSRC = qr_ed_example.c qr_ed.c qrlib/*.c 

all: qr

qr: $(CSRC)
	gcc $(CSRC) $(CFLAGS) -o qr


clean:
	rm -f qr
