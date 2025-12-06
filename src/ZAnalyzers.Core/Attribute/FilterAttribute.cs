namespace ZAnalyzers.Core
{
	/// <summary>
	/// 指定端点类型过滤器
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class FilterAttribute : System.Attribute
	{
		/// <summary>
		/// 过滤器类型
		/// </summary>
		public Type[] Types { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="types"></param>
		public FilterAttribute(params Type[] types)
		{
			Types = types;
		}
	}
}
