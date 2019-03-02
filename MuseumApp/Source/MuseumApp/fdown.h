/* 
 * returns download success 
 * url     : url of file to download
 * out_f   : local file destination
 * err_buf : buffer to write error message to
 *           err_buf can be safely set to NULL
 */
_Bool dl_file(char* url, char* out_f, char* err_buf);
