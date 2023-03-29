using System;
using ProtoBuf;
using ProtoBuf.Meta;
using Rebus.Protobuf;
using Rebus.Serialization;
// ReSharper disable UnusedMember.Global

namespace Rebus.Config;

/// <summary>
/// Configuration extensions for the Rebus Protobuf serializer
/// </summary>
public static class ProtobufSerializerConfigurationExtensions
{
    /// <summary>
    /// Configures Rebus to use the Protobuf serializer with the default protobuf-net settings (i.e. with the <see cref="RuntimeTypeModel.Default"/> instance
    /// of the <see cref="RuntimeTypeModel"/>, requiring you to either decorate your type with appropriate <see cref="ProtoMemberAttribute"/> or
    /// supplying appropriate metadata to the default instance)
    /// </summary>
    public static void UseProtobuf(this StandardConfigurer<ISerializer> configurer)
    {
        if (configurer == null) throw new ArgumentNullException(nameof(configurer));
        configurer.Register(_ => new ProtobufSerializer());
    }

    /// <summary>
    /// Configures Rebus to use the Protobuf serializer with the given <see cref="RuntimeTypeModel"/>, requiring you to either decorate your type with 
    /// appropriate <see cref="ProtoMemberAttribute"/> or supplying appropriate metadata to the instance passed in)
    /// </summary>
    public static void UseProtobuf(this StandardConfigurer<ISerializer> configurer, RuntimeTypeModel runtimeTypeModel)
    {
        if (configurer == null) throw new ArgumentNullException(nameof(configurer));
        if (runtimeTypeModel == null) throw new ArgumentNullException(nameof(runtimeTypeModel));
        configurer.Register(_ => new ProtobufSerializer(runtimeTypeModel));
    }
}