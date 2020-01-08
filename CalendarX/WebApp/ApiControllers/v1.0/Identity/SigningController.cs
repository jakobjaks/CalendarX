using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.BLL.Base;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Cors;

namespace WebApp.ApiControllers.v1._0
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SingingController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SingingController(IAppBLL bll)
        {
            _bll = bll;
        }

        [HttpPost("{generateHash}")]
        public async Task<ActionResult<string>> Sign(string signatureHex)
        {
            return signatureHex;
//            new IronPdf.PdfSignature().SignPdfFile();
        }
    }
}