
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OMS.Components;
using OMS.Datacontracts;
using System;
using static OMS.Components.Message;

namespace OMS.Controllers
{
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        IOptions<OMSConnection> _connectionSettings;
        public OrderController(IOptions<OMSConnection> connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        /// <summary>
        /// Get order by orderid
        /// </summary>
        /// <param name="Orderid"></param>
        /// <returns></returns>
        [HttpGet("{Orderid}")]
        public ResponseMessage GetOrder([FromRoute]int Orderid)
        {

            ResponseMessage objResponseMessage = new ResponseMessage();

            try
            {

                Order order = new Order();
                OrderComp orderComp = new OrderComp(_connectionSettings);
                order = orderComp.GetOrderDetailsByOrderId(Orderid);
                objResponseMessage.Order = order;
                objResponseMessage.Code = MessageCode.Success;
                objResponseMessage.Message = "Order retrieved succesfully";
                
            }
            catch (System.Exception ex)
            {
                ex.Data["Method"] = "GetOrder";
                ex.Data["Component"] = "OrderController";

                objResponseMessage.Code = MessageCode.Exception;
                objResponseMessage.Message = ex.Message;
            }

            return objResponseMessage;

        }

        /// <summary>
        /// Save Order
        /// </summary>
        /// <param name="OrderInformation"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseMessage SaveOrder([FromBody]Order OrderInformation)
        {
            ResponseMessage objResponseMessage = new ResponseMessage();
            try
            {
                OrderComp orderComp = new OrderComp(_connectionSettings);
                long OrderId = orderComp.Saveorder(OrderInformation);
                objResponseMessage.OrderID = OrderId.ToString();
                objResponseMessage.Code = MessageCode.Success;
                objResponseMessage.Message = "Order created successfully";

            }
            catch (System.Exception ex)
            {

                ex.Data["Method"] = "SaveOrder";
                ex.Data["Component"] = "OrderController";

                objResponseMessage.Code = MessageCode.Exception;
                objResponseMessage.Message = ex.Message;
            }
            return objResponseMessage;

        }

       /// <summary>
       /// Delete order by order id
       /// </summary>
       /// <param name="Orderid"></param>
       /// <returns></returns>
        [HttpDelete("{Orderid}")]
        public ResponseMessage DeleteOrder([FromRoute]long Orderid)
        {
            ResponseMessage objResponseMessage = new ResponseMessage();
            try
            {
                OrderComp orderComp = new OrderComp(_connectionSettings);
                orderComp.DeleteOrder(Orderid);
               
                objResponseMessage.Code = MessageCode.Success;
                objResponseMessage.Message = "Order deleted successfully";
            }
            catch (Exception ex)
            {
                ex.Data["Method"] = "DeleteOrder";
                ex.Data["Component"] = "OrderController";

                objResponseMessage.Code = MessageCode.Exception;

            }
            return objResponseMessage;

        }
    }
}
