String.prototype.Concat = function () {
    var args = arguments,
        self = args.length ? this : [];
    if (!args.length) args = this;
    for (index = 0, source = self; index < args.length; index++)
        source += args[index];
    return source;
};