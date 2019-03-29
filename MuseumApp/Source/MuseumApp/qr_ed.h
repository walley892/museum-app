#include <stdint.h>

/* returns success - width, height are written into wh[0], wh[1] */
_Bool get_dimensions_png(char* fname, int* wh);
/* returns NULL on failure, NULL terminated array of qr code text on success */
uint8_t* decode_qr(char* fname);
