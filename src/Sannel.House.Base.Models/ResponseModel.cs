/* Copyright 2019-2020 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the ""License"");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an ""AS IS"" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/
using System;
using System.Net;
using System.Text.Json.Serialization;

namespace Sannel.House.Base.Models
{
	/// <summary>
	/// The base response model for api responses
	/// </summary>
	public class ResponseModel : IResponse
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel"/> class.
		/// </summary>
		public ResponseModel() : this(HttpStatusCode.OK, string.Empty)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel"/> class.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		public ResponseModel(int statusCode) : this(statusCode, string.Empty)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel"/> class.
		/// </summary>
		/// <param name="code">The status code.</param>
		public ResponseModel(HttpStatusCode code) : this((int)code, string.Empty)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel"/> class.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		/// <param name="title">The title.</param>
		public ResponseModel(int statusCode, string title)
		{
			Title = title;
			Status = statusCode;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel"/> class.
		/// </summary>
		/// <param name="code">The status code.</param>
		/// <param name="title">The title.</param>
		public ResponseModel(HttpStatusCode code, string title) : this((int)code, title)
		{ }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		[JsonPropertyName("status")]
		public int Status { get; set; } = 200;

		/// <summary>
		/// Gets the status code.
		/// </summary>
		/// <value>
		/// The status code.
		/// </value>
		[JsonIgnore]
		public HttpStatusCode StatusCode => (HttpStatusCode)Status;

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		[JsonPropertyName("title")]
		public string Title { get; set; }
	}

	/// <summary>
	/// The base response model with data api responses
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ResponseModel<T> : ResponseModel, IResponse<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel{T}"/> class.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		/// <param name="title">The title.</param>
		/// <param name="data">The data.</param>
		public ResponseModel(int statusCode, string title, T data) : base(statusCode, title)
			=> Data = data;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel{T}"/> class.
		/// </summary>
		/// <param name="code">The status code.</param>
		/// <param name="title">The title.</param>
		/// <param name="data">The data.</param>
		public ResponseModel(HttpStatusCode code, string title, T data) : base(code, title) 
			=> Data = data;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel{T}"/> class.
		/// </summary>
		/// <param name="code">The status code.</param>
		/// <param name="data">The data.</param>
		public ResponseModel(HttpStatusCode code, T data) : this(code, string.Empty, data)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel{T}"/> class.
		/// </summary>
		/// <param name="code">The status code.</param>
		/// <param name="data">The data.</param>
		public ResponseModel(int code, T data) : this(code, string.Empty, data)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel{T}"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="data">The data.</param>
		public ResponseModel(string title, T data) : this(HttpStatusCode.OK, title, data)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseModel{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public ResponseModel(T data) : this(HttpStatusCode.OK, string.Empty, data)
		{

		}


		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		[JsonPropertyName("data")]
		public T Data { get; set; }
	}
}
