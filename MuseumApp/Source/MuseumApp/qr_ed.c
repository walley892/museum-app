#include <stdlib.h>

#include "qrlib/quirc.h"
/* this file has been moved from tests to lib */
#include "qrlib/dbgutil.h"

#include "qr_ed.h"

#define SCR_RES 200, 500

uint8_t* decode_qr(char* fname){
      struct quirc* qr = quirc_new();
      // not enough memory
      if(!qr)return NULL;

      quirc_resize(qr, SCR_RES);

      uint8_t* pic;
      int w, h;
      pic = quirc_begin(qr, &w, &h);

      // need to populate pic[w,h]
      // load_* return 0 on success
      if(check_if_png(fname)){
            if(load_png(qr, fname))return NULL;
      }
      else if(load_jpeg(qr, fname))return NULL;

      quirc_end(qr);

      uint8_t* ret = NULL;

      struct quirc_code code;
      struct quirc_data data;
      quirc_decode_error_t err;

      quirc_extract(qr, 0, &code);
      if((err = quirc_decode(&code, &data)))
           ret = NULL;
      else ret = data.payload;

      quirc_destroy(qr);

      return ret;
}
