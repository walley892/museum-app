#include <stdio.h>
#include <string.h>

#include <CUnit/CUnit.h>
#include <CUnit/Basic.h>


/* Runs a test input that *should* pass and produce an int result
 */

void test0(){
      CU_ASSERT_TRUE(1);
}

/* */

/* The main() function for setting up and running the tests.
 * Returns a CUE_SUCCESS on successful running, another
 * CUnit error code on failure.
 */
int main()
{
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
          (!CU_add_test(Suite, "test0", test0))
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
