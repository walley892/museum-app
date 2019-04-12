#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "fdown.h"

#include <CUnit/CUnit.h>
#include <CUnit/Basic.h>


/* Runs a test input that *should* pass and produce an int result
 */

void dl_file_txt_tst(){
      dl_file("http://www.acsu.buffalo.edu/~asherlie/fdown_test", ".tmp_out_f", NULL);
      FILE* fp = fopen(".tmp_out_f", "r");
      char* ln = NULL;
      size_t sz = 0;
      int len = getline(&ln, &sz, fp);
      ln[len-1] = 0;
      fclose(fp);
      remove(".tmp_out_f");
      _Bool ret = strcmp("this is a sample file", ln) == 0;
      free(ln);
      CU_ASSERT_TRUE(ret);
}

void dl_file_sz_tst(){
      dl_file("https://upload.wikimedia.org/wikipedia/en/e/eb/University_at_Buffalo_seal.svg", ".tmp_out_f", NULL);
      _Bool ret;
      FILE* fp = fopen(".tmp_out_f", "r");
      ret = fp;
      int sz = 0;
      while(fgetc(fp) != EOF)++sz;
      ret &= sz == 89253;
      remove(".tmp_out_f");
      CU_ASSERT_TRUE(ret);
}

/* */

/* The main() function for setting up and running the tests.
 * Returns a CUE_SUCCESS on successful running, another
 * CUnit error code on failure.
 */
int main(){
   CU_pSuite Suite = NULL;

   /* initialize the CUnit test registry */
   if (CUE_SUCCESS != CU_initialize_registry()) { return CU_get_error(); }

   /* add a suite to the registry */
   Suite = CU_add_suite("Suite_of_tests_with_valid_inputs", NULL, NULL);
   if (NULL == Suite) {
      CU_cleanup_registry();
      return CU_get_error();
   }

   /* add the tests to Suite */
   if (
          (!CU_add_test(Suite, "dl_file_sz_tst", dl_file_sz_tst))
        ||(!CU_add_test(Suite, "dl_file_txt_tst", dl_file_txt_tst))
      )
   {
      CU_cleanup_registry();
      return CU_get_error();
   }

   /* Run all tests using automated interface, with output to 'test-Results.xml' */
   CU_basic_run_tests();

   CU_cleanup_registry();
   return CU_get_error();
}
