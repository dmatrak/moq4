// Copyright (c) 2007, Clarius Consulting, Manas Technology Solutions, InSTEDD.
// All rights reserved. Licensed under the BSD 3-Clause License; see License.txt.

using System;
using System.Reflection;

namespace Moq
{
	internal abstract class ProxyFactory
	{
		/// <summary>
		/// Gets the global <see cref="ProxyFactory"/> instance used by Moq.
		/// </summary>
		public static ProxyFactory Instance { get; } = new CastleProxyFactory();

		public abstract object CreateProxy(Type mockType, IInterceptor interceptor, Type[] interfaces, object[] arguments);

		public abstract bool IsMethodVisible(MethodInfo method, out string messageIfNotVisible);

		public abstract bool IsTypeVisible(Type type);

		/// <summary>
		/// Gets an autogenerated interface with a method on it that matches the signature of the specified
		/// <paramref name="delegateType"/>.
		/// </summary>
		/// <remarks>
		/// Such an interface can then be mocked, and a delegate pointed at the method on the mocked instance.
		/// This is how we support delegate mocking.  The factory caches such interfaces and reuses them
		/// for repeated requests for the same delegate type.
		/// </remarks>
		/// <param name="delegateType">The delegate type for which an interface is required.</param>
		/// <param name="delegateInterfaceMethod">The method on the autogenerated interface.</param>
		public abstract Type GetDelegateProxyInterface(Type delegateType, out MethodInfo delegateInterfaceMethod);
	}
}
