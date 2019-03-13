#include <stdlib.h>
#include <png.h>

#include "qrlib/quirc.h"
/* this file has been moved from tests to lib */
#include "qrlib/dbgutil.h"

#include "qr_ed.h"

#define SCR_RES 200, 500

// returns width, height
int* get_dimensions_png(char* fname){
      int* ret = NULL;
      FILE* fp = fopen(fname, "rb");
      if(!fp)return NULL;

      png_structp img = png_create_read_struct(PNG_LIBPNG_VER_STRING, NULL, NULL, NULL);
      if(!img)goto cleanup_fp;
      png_infop inf = png_create_info_struct(img);
      if(!inf)goto cleanup_fp;

      // ... libpng documentation told me to http://www.libpng.org/pub/png/libpng-1.2.5-manual.html
      if(setjmp(png_jmpbuf(img)))goto cleanup_fp;

      png_init_io(img, fp);
      png_read_info(img, inf);

      ret = malloc(sizeof(int)*2);
      ret[0] = png_get_image_width(img, inf);
      ret[1] = png_get_image_height(img, inf);

      cleanup_inf:
      png_destroy_read_struct(&img, &inf, NULL);
      cleanup_fp:
      fclose(fp);
      return ret;
}

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
      // printf("got \"%s\"/%i\n", data.payload, data.payload);

      quirc_destroy(qr);

      return ret;
}
