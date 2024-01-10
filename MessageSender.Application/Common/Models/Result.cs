using System.Runtime.Serialization;
using MessageSender.Application.Common.Enums;

namespace MessageSender.Application.Common.Models;

    /// <summary>
    /// Represents result of unreliable operation by specific enum error code and message.
    /// </summary>
    [DataContract]
    public class Result
    {
        /// <inheritdoc cref="Result"/>
        public Result() { }

        /// <inheritdoc cref="Result"/>
        /// <param name="code">Operation result status code.</param>
        /// <param name="message">Operation result message.</param>
        public Result(StatusCodes code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Operation status code.
        /// </summary>
        [DataMember(Name = "code", Order = 1)]
        public virtual StatusCodes Code { get; set; }


        /// <summary>
        /// Operation status message.
        /// </summary>
        [DataMember(Name = "message", Order = 2)]
        public virtual string Message { get; set; }
    }


    /// <summary>
    /// Represents result of unreliable operation by specific enum error code, message and data returned by operation.
    /// </summary>
    [DataContract]
    public class Result<TData> : Result
    {
        /// <inheritdoc cref="Result"/>
        public Result() { }

        /// <inheritdoc cref="Result(StatusCodes, string)"/>
        public Result(StatusCodes code, string message) : base(code, message) { }

        /// <inheritdoc cref="Result(StatusCodes, string)"/>
        /// <param name="data">Operation result data.</param>
        public Result(StatusCodes code, string message, TData data) : base(code, message)
        {
            Data = data;
        }

        /// <summary>
        /// <inheritdoc cref="Result.Code"/>
        /// </summary>
        [DataMember(Name = "code", Order = 1)]
        public override StatusCodes Code { get; set; }

        /// <summary>
        /// <inheritdoc cref="Result.Message"/>
        /// </summary>
        [DataMember(Name = "message", Order = 2)]
        public override string Message { get; set; }

        /// <summary>
        /// Operation result data.
        /// </summary>
        [DataMember(Name = "data", Order = 3)]
        public TData Data { get; set; }
    }