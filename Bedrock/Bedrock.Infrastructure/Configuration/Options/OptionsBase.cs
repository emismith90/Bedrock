using System.Runtime.CompilerServices;

namespace Bedrock.Infrastructure.Configuration.Options
{
    public class OptionsBase
    {
        protected virtual string SectionName => this.GetType().Name.Replace("Options", string.Empty);
        protected readonly IAppSetting _appSettings;

        public OptionsBase(IAppSetting appSettings)
        {
            _appSettings = appSettings;
        }

        protected string GetString([CallerMemberName]string subKey = "")
        {
            return _appSettings?.GetSection(SectionName)?[subKey];
        }

        protected int? GetInt([CallerMemberName]string subKey = "")
        {
            if (int.TryParse(_appSettings?.GetSection(SectionName)?[subKey], out int i))
            {
                return i;
            }

            return null;
        }

        protected double? GetDecimal([CallerMemberName]string subKey = "")
        {
            if (double.TryParse(_appSettings?.GetSection(SectionName)?[subKey], out double i))
            {
                return i;
            }

            return null;
        }

        protected bool? GetBoolean([CallerMemberName]string subKey = "")
        {
            if (bool.TryParse(_appSettings?.GetSection(SectionName)?[subKey], out bool i))
            {
                return i;
            }

            return null;
        }
    }
}
