#if 0
* build instructions:
* gcc qr_ed_example.c qr_ed.c qrlib/quirc.c qrlib/decode.c
* qrlib/dbgutil.c qrlib/identify.c qrlib/version_db.c -o qr_ex
* -ljpeg -lpng -lm
*
*  or just
*
*  gcc qr_ed_example.c qr_ed.c qrlib/ *.c -ljpeg -lpng -lm
#endif

#include <stdio.h>

#include "qr_ed.h"

int main(int a, char** b){
      if(a < 2)return 1;
      int n_qr;
      uint8_t** qq = decode_qr(b[1], &n_qr);
      if(!qq || n_qr == 0){
            puts("oops! couldn't decode any qr codes");
            return 1;
      }
      printf("%i qr codes found\n", n_qr);
      for(int i = 0; i < n_qr; ++i)
            puts((char*)qq[i]);
      return 0;
}
