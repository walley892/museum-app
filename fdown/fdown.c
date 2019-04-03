#include <curl/curl.h>
#include <stdio.h>
#include <string.h>

#include "fdown.h"

/*
 * if err_buf is not NULL, the CURL error message, 
 * if it exists is copied into the buffer
 */
_Bool dl_file(char* url, char* out_f, char* err_buf){
      FILE* fp = fopen(out_f, "wb");
      if(!fp)return 0;
      CURL* curl; CURLcode ret;
      if(!(curl = curl_easy_init()))return 0;
      curl_easy_setopt(curl, CURLOPT_URL, url);
      curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, NULL);
      curl_easy_setopt(curl, CURLOPT_WRITEDATA, fp);
      ret = curl_easy_perform(curl);
      if(err_buf)strncpy(err_buf, curl_easy_strerror(ret), 50);
      curl_easy_cleanup(curl);
      fclose(fp);
      // ret == 0 on success
      return !ret;
}
