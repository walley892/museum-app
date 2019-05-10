using System;
using System.Text;
using System.IO;  
using System.Web;
using System.Net;  

namespace art_dl{

      public class artifact_dl{

            private static string base_url = "http://35.202.157.90/";
            private static string dl_dir = base_url + "getArtifactInfo?artifact_id=";
            //private static string up_route = "http://35.202.157.90/uploads/";
            private static string up_route = base_url+"uploads/";

            string json, _id, _save_path;

            public artifact_dl(string id, string save_path){
                  json = get_art_url(id);
                  _id = id;
                  _save_path = save_path;
            }

            static string parse_json(string entry, string json){
                  int ind = json.IndexOf("\"" + entry + "\":");
                  if(ind == -1)return null;
                  int ln = entry.Length+3;
                  /* found is not in quotes */
                  return json.Substring(ind+ln+1, json.Substring(ind+ln+1).IndexOf("\""));
            }

            public string[] get_all_models(){
                  WebRequest request = WebRequest.Create(base_url+"getModels");
                  WebResponse response = request.GetResponse();
                  string ret;
                  using (Stream responseStream = response.GetResponseStream()){
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        ret = rdr.ReadToEnd();
                        rdr.Close();
                  }
                  /* TODO: parse this json and return list of all _ids */
                  string[] spl = ret.Split(new char[] {'_', 'i', 'd'});
                  return spl;
            }

            static string get_art_url(string art_id){
                  WebRequest request = WebRequest.Create(dl_dir+art_id);
                  WebResponse response = request.GetResponse();
                  string ret;
                  using (Stream responseStream = response.GetResponseStream()){
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        ret = rdr.ReadToEnd();
                        rdr.Close();
                  }
                  return ret;
            }

            public string get_model(){
                  string fpath = _save_path+"/model_"+_id;
                  using (WebClient client = new WebClient()){
                        //client.DownloadFile(up_route+parse_json("modelPath", json), _id+"_model");
                        client.DownloadFile(up_route+parse_json("modelPath", json), fpath);
                  }
                  return fpath;
            }

            public string get_texture(){
                  using (WebClient client = new WebClient()){
                        client.DownloadFile(up_route+parse_json("texturePath", json), _id+"_texture");
                  }
                  return _id+"_texture";
            }

      }

}
