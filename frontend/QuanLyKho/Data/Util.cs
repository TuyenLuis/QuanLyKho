using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using RestSharp;
using Constant;

namespace Data
{
    public class Util
    {
        public static ResponseData GenerateErrorResponse(IRestResponse response, dynamic responseParse)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new ResponseData()
                {
                    Status = Config.CODE_UNAUTHORIZED,
                    Data = null,
                    Message = responseParse["message"]
                };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return new ResponseData()
                {
                    Status = Config.CODE_SERVER_ERROR,
                    Data = null,
                    Message = responseParse["err"] != null ? responseParse["err"] : responseParse["error"]
                };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return new ResponseData()
                {
                    Status = Config.CODE_FORBIDDEN,
                    Data = null,
                    Message = responseParse["message"]
                };
            }
            else
            {
                return null;
            }
        }
    }
}
