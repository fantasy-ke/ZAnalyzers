namespace ZAnalyzers.Core
{
	public class ZAnalyzerOption
	{
		public bool? DisableAutoMapRoute { get; set; }

		/// <summary>
		/// The prefix, the default is null
		/// Formatter is $"{Prefix}/{Version}/{ServiceName}", any one IsNullOrWhiteSpace would be ignored.
		/// Formatter 是 $“{Prefix}/{Version}/{ServiceName}”，任何一个 IsNullOrWhiteSpace 都会被忽略。
		/// </summary>
		public string? Prefix { get; set; }

		/// <summary>
		/// The default is Null
		/// Formatter is $"{Prefix}/{Version}/{ServiceName}", any one IsNullOrWhiteSpace would be ignored.
		/// Formatter 是 $“{Prefix}/{Version}/{ServiceName}”，任何一个 IsNullOrWhiteSpace 都会被忽略。
		/// </summary>
		public string? Version { get; set; }

		public bool? AutoAppendId { get; set; }

		/// <summary>
		/// The default is Null
		/// 服务名称复数化
		/// </summary>
		public bool? PluralizeServiceName { get; set; }

		public List<string>? GetPrefixes { get; set; }

		public List<string>? PostPrefixes { get; set; }

		public List<string>? PutPrefixes { get; set; }

		public List<string>? DeletePrefixes { get; set; }

		/// <summary>
		/// Disable removing the request method prefix that matches the method name
		/// 禁用与方法名称匹配的请求方法前缀
		/// </summary>
		public bool? DisableTrimMethodPrefix { get; set; }

		/// <summary>
		/// After matching request type by prefix fails
		/// 通过前缀匹配请求类型后，失败
		/// Use the request type when matching the request method based on the prefix fails
		/// 在匹配基于前缀的请求方法时使用请求类型，失败
		/// When the collection is empty, the default Post, Get, Put, Delete all support access
		/// 当集合为空时，默认的Post, Get, Put, Delete所有支持访问
		/// </summary>
		public string[] MapHttpMethodsForUnmatched { get; set; } = Array.Empty<string>();

		/// <summary>
		/// Enable access to public properties
		/// 允许访问公共属性
		/// default: false
		/// </summary>
		public bool? EnableProperty { get; set; }
	}
}
