#include <curl/curl.h>
#include <stdio.h>
#include <string.h>


/*
 * if err_buf is not NULL, the CURL error message, 
 * if it exists is copied into the buffer
 */
int dl_file(char* in_f, char* out_f, char* err_buf){
      FILE* fp; CURL* curl;
      CURLcode ret;
      if((curl = curl_easy_init())){
            fp = fopen(out_f, "wb");
            if(!fp)return 0;
            curl_easy_setopt(curl, CURLOPT_URL, in_f);
            curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, NULL);
            curl_easy_setopt(curl, CURLOPT_WRITEDATA, fp);
            ret = curl_easy_perform(curl);
            if(err_buf)strncpy(err_buf, curl_easy_strerror(ret), 50);
            curl_easy_cleanup(curl);
            fclose(fp);
      }
      else return 0;
      // on success ret == 0
      return !ret;
}

int main(int a, char** b){
      if(a < 3)return 1;
      int ret;
      char e_b[51] = {0};
      if(!(ret = dl_file(b[1], b[2], e_b)))printf("failed to download file... curl returned error: %s\n", e_b);
      return !ret;
}
