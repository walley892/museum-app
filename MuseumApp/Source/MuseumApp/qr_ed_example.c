/* build instructions:
 * gcc qr_ed_example.c qr_ed.c qrlib/quirc.c qrlib/decode.c
 * qrlib/dbgutil.c qrlib/identify.c qrlib/version_db.c -o qr_ex
 * -ljpeg -lpng
 *
 *  or just
 *
 *  gcc qr_ed_example.c qr_ed.c qrlib/*.c
 */

#include <stdio.h>

#include "qr_ed.h"

int main(int a, char** b){
      printf("%s\n", decode_qr(b[1]));
      return 0;
}
