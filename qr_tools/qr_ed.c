#include <stdlib.h>
#include <png.h>
#include <string.h>

#include "qrlib/quirc.h"
/* this file has been moved from tests to lib */
#include "qrlib/dbgutil.h"

#include "qr_ed.h"

_Bool get_dimensions_png(char* fname, int* wh){
      FILE* fp = fopen(fname, "rb");
      if(!fp)return 0;

      png_structp img = png_create_read_struct(PNG_LIBPNG_VER_STRING, NULL, NULL, NULL);
      png_infop inf = png_create_info_struct(img);
      if(!img || !inf)goto cleanup_fp;

      // ... libpng documentation told me to http://www.libpng.org/pub/png/libpng-1.2.5-manual.html
      if(setjmp(png_jmpbuf(img)))goto cleanup_inf;

      png_init_io(img, fp);
      png_read_info(img, inf);

      wh[0] = png_get_image_width(img, inf);
      wh[1] = png_get_image_height(img, inf);

      cleanup_inf:
      png_destroy_read_struct(&img, &inf, NULL);
      cleanup_fp:
      fclose(fp);
      return img && fp && inf;
}

uint8_t** decode_qr(char* fname, int* n_qr){
      struct quirc* qr = quirc_new();

      _Bool png;
      // limiting scope of dim
      {
      // jpeg dimensions will always be 200, 500 bc... idk...
      int dim[2] = {200, 500};
      if((png = check_if_png(fname)))
            get_dimensions_png(fname, dim);
      quirc_resize(qr, dim[0], dim[1]);
      }

      // not enough memory
      if(!qr)return NULL;

      int w, h;
      quirc_begin(qr, &w, &h);

      // load_* return 0 on success
      if(png){
            if(load_png(qr, fname))return NULL;
      }
      else if(load_jpeg(qr, fname))return NULL;

      quirc_end(qr);

      /* actual decoding is done here */
      
      *n_qr = quirc_count(qr);

      uint8_t** ret = calloc(*n_qr+1, sizeof(uint8_t*)), * tmp;

      for(int i = 0, n = 0; i < *n_qr; ++i){
            struct quirc_code code;
            struct quirc_data data;
            quirc_decode_error_t err;

            quirc_extract(qr, i, &code);
            if(!(err = quirc_decode(&code, &data)))
                  ret[n++] = memcpy(tmp = malloc(data.payload_len+1),
                                    data.payload, data.payload_len);
      }

      quirc_destroy(qr);

      return ret;
}
