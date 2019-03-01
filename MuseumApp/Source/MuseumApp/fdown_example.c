#include "fdown_example.h"

int main(int a, char** b){
      if(a < 3)return 1;
      int ret;
      char e_b[51] = {0};
      if(!(ret = dl_file(b[1], b[2], e_b)))
            printf("failed to download file... curl returned error: %s\n", e_b);
      return !ret;
}
