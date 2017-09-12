using System;
using System.Collections.Generic;
using System.Linq;

namespace Incontrl.Net.Models
{
    public class CountryInfo
    {
        public static readonly ICollection<CountryInfo> Countries;

        static CountryInfo() => Countries = new List<CountryInfo>
        {
            { new CountryInfo("Afghanistan", "AF", 4, "prs,ps,uz") },
            { new CountryInfo("Åland Islands", "AX", 248, "sv") },
            { new CountryInfo("Albania", "AL", 8, "sq") },
            { new CountryInfo("Algeria", "DZ", 12, "ar,fr,kab,tzm") },
            { new CountryInfo("American Samoa", "AS", 16, "en") },
            { new CountryInfo("Andorra", "AD", 20, "ca") },
            { new CountryInfo("Angola", "AO", 24, "ln,pt") },
            { new CountryInfo("Anguilla", "AI", 660, "en") },
            { new CountryInfo("Antarctica", "AQ", 10, "") },
            { new CountryInfo("Antigua and Barbuda", "AG", 28, "en") },
            { new CountryInfo("Argentina", "AR", 32, "es") },
            { new CountryInfo("Armenia", "AM", 51, "hy") },
            { new CountryInfo("Aruba", "AW", 533, "nl") },
            { new CountryInfo("Australia", "AU", 36, "en") },
            { new CountryInfo("Austria", "AT", 40, "en,de") },
            { new CountryInfo("Azerbaijan", "AZ", 31, "az") },
            { new CountryInfo("Bahamas", "BS", 44, "en") },
            { new CountryInfo("Bahrain", "BH", 48, "ar") },
            { new CountryInfo("Bangladesh", "BD", 50, "bn") },
            { new CountryInfo("Barbados", "BB", 52, "en") },
            { new CountryInfo("Belarus", "BY", 112, "be,ru") },
            { new CountryInfo("Belgium", "BE", 56, "fr,de,en,nl") },
            { new CountryInfo("Belize", "BZ", 84, "en") },
            { new CountryInfo("Benin", "BJ", 204, "fr,yo") },
            { new CountryInfo("Bermuda", "BM", 60, "en") },
            { new CountryInfo("Bhutan", "BT", 64, "dz") },
            { new CountryInfo("Bolivia, Plurinational State of", "BO", 68, "es,quz") },
            { new CountryInfo("Bonaire, Sint Eustatius and Saba", "BQ", 535, "nl") },
            { new CountryInfo("Bosnia and Herzegovina", "BA", 70, "bs,hr,sr") },
            { new CountryInfo("Botswana", "BW", 72, "en,tn") },
            { new CountryInfo("Bouvet Island", "BV", 74, "") },
            { new CountryInfo("Brazil", "BR", 76, "es,pt") },
            { new CountryInfo("British Indian Ocean Territory", "IO", 86, "en") },
            { new CountryInfo("Brunei Darussalam", "BN", 96, "ms") },
            { new CountryInfo("Bulgaria", "BG", 100, "bg") },
            { new CountryInfo("Burkina Faso", "BF", 854, "fr") },
            { new CountryInfo("Burundi", "BI", 108, "rn,en,fr") },
            { new CountryInfo("Cambodia", "KH", 116, "km") },
            { new CountryInfo("Cameroon", "CM", 120, "agq,bas,dua,en,ewo,ff,fr,jgo,kkj,ksf,mgo,mua,nmg,nnh,yav") },
            { new CountryInfo("Canada", "CA", 124, "en,fr,iu,iu,moh") },
            { new CountryInfo("Cape Verde", "CV", 132, "kea,pt") },
            { new CountryInfo("Cayman Islands", "KY", 136, "en") },
            { new CountryInfo("Central African Republic", "CF", 140, "fr,ln,sg") },
            { new CountryInfo("Chad", "TD", 148, "ar,fr") },
            { new CountryInfo("Chile", "CL", 152, "arn,es") },
            { new CountryInfo("China", "CN", 156, "bo,ii,mn,ug,zh") },
            { new CountryInfo("Christmas Island", "CX", 162, "en") },
            { new CountryInfo("Cocos (Keeling) Islands", "CC", 166, "en") },
            { new CountryInfo("Colombia", "CO", 170, "es") },
            { new CountryInfo("Comoros", "KM", 174, "ar,fr") },
            { new CountryInfo("Congo", "CG", 178, "fr,ln") },
            { new CountryInfo("Congo, the Democratic Republic of the", "CD", 180, "fr,ln,lu,sw") },
            { new CountryInfo("Cook Islands", "CK", 184, "en") },
            { new CountryInfo("Costa Rica", "CR", 188, "es") },
            { new CountryInfo("C“te d'Ivoire", "CI", 384, "fr") },
            { new CountryInfo("Croatia", "HR", 191, "hr") },
            { new CountryInfo("Cuba", "CU", 192, "es") },
            { new CountryInfo("Cura‡ao", "CW", 531, "nl") },
            { new CountryInfo("Cyprus", "CY", 196, "el,en,tr") },
            { new CountryInfo("Czech Republic", "CZ", 203, "cs") },
            { new CountryInfo("Denmark", "DK", 208, "da,en,fo") },
            { new CountryInfo("Djibouti", "DJ", 262, "aa,ar,fr,so") },
            { new CountryInfo("Dominica", "DM", 212, "en") },
            { new CountryInfo("Dominican Republic", "DO", 214, "es") },
            { new CountryInfo("Ecuador", "EC", 218, "es,quz") },
            { new CountryInfo("Egypt", "EG", 818, "ar") },
            { new CountryInfo("El Salvador", "SV", 222, "es") },
            { new CountryInfo("Equatorial Guinea", "GQ", 226, "es,fr,pt") },
            { new CountryInfo("Eritrea", "ER", 232, "aa,ar,byn,en,ssy,ti,tig") },
            { new CountryInfo("Estonia", "EE", 233, "et") },
            { new CountryInfo("Ethiopia", "ET", 231, "aa,am,om,so,ti,wal") },
            { new CountryInfo("Falkland Islands (Malvinas)", "FK", 238, "en") },
            { new CountryInfo("Faroe Islands", "FO", 234, "fo") },
            { new CountryInfo("Fiji", "FJ", 242, "en") },
            { new CountryInfo("Finland", "FI", 246, "en,fi,se,smn,sms,sv") },
            { new CountryInfo("France", "FR", 250, "br,ca,co,fr,gsw,ia,oc") },
            { new CountryInfo("French Guiana", "GF", 254, "fr") },
            { new CountryInfo("French Polynesia", "PF", 258, "fr") },
            { new CountryInfo("French Southern Territories", "TF", 260, "") },
            { new CountryInfo("Gabon", "GA", 266, "fr") },
            { new CountryInfo("Gambia", "GM", 270, "en") },
            { new CountryInfo("Georgia", "GE", 268, "ka,os") },
            { new CountryInfo("Germany", "DE", 276, "de,dsb,en,hsb,ksh,nds") },
            { new CountryInfo("Ghana", "GH", 288, "ak,ee,en,ha") },
            { new CountryInfo("Gibraltar", "GI", 292, "en") },
            { new CountryInfo("Greece", "GR", 300, "el") },
            { new CountryInfo("Greenland", "GL", 304, "da,kl") },
            { new CountryInfo("Grenada", "GD", 308, "en") },
            { new CountryInfo("Guadeloupe", "GP", 312, "fr") },
            { new CountryInfo("Guam", "GU", 316, "en") },
            { new CountryInfo("Guatemala", "GT", 320, "es,quc") },
            { new CountryInfo("Guernsey", "GG", 831, "en") },
            { new CountryInfo("Guinea", "GN", 324, "ff,fr,nqo") },
            { new CountryInfo("Guinea-Bissau", "GW", 624, "pt") },
            { new CountryInfo("Guyana", "GY", 328, "en") },
            { new CountryInfo("Haiti", "HT", 332, "fr,zh") },
            { new CountryInfo("Heard Island and McDonald Islands", "HM", 334, "") },
            { new CountryInfo("Holy See (Vatican City State)", "VA", 336, "") },
            { new CountryInfo("Honduras", "HN", 340, "es") },
            { new CountryInfo("Hong Kong", "HK", 344, "en,zh,zh") },
            { new CountryInfo("Hungary", "HU", 348, "hu") },
            { new CountryInfo("Iceland", "IS", 352, "is") },
            { new CountryInfo("India", "IN", 356, "as,bn,bo,brx,en,gu,hi,kn,kok,ks,ks,ml,mni,mr,ne,or,pa,sa,sd,ta,te,ur") },
            { new CountryInfo("Indonesia", "ID", 360, "en,id,jv,jv") },
            { new CountryInfo("Iran, Islamic Republic of", "IR", 364, "fa,ku,lrc,mzn") },
            { new CountryInfo("Iraq", "IQ", 368, "ar,ku,lrc") },
            { new CountryInfo("Ireland", "IE", 372, "en,ga") },
            { new CountryInfo("Isle of Man", "IM", 833, "en,gv") },
            { new CountryInfo("Israel", "IL", 376, "ar,en,he") },
            { new CountryInfo("Italy", "IT", 380, "ca,de,fur,it") },
            { new CountryInfo("Jamaica", "JM", 388, "en") },
            { new CountryInfo("Japan", "JP", 392, "ja") },
            { new CountryInfo("Jersey", "JE", 832, "en") },
            { new CountryInfo("Jordan", "JO", 400, "ar") },
            { new CountryInfo("Kazakhstan", "KZ", 398, "kk,ru") },
            { new CountryInfo("Kenya", "KE", 404, "dav,ebu,en,guz,kam,ki,kln,luo,luy,mas,mer,om,saq,so,sw,teo") },
            { new CountryInfo("Kiribati", "KI", 296, "en") },
            { new CountryInfo("Korea, Democratic People's Republic of", "KP", 408, "ko") },
            { new CountryInfo("Korea, Republic of", "KR", 410, "ko") },
            { new CountryInfo("Kuwait", "KW", 414, "ar") },
            { new CountryInfo("Kyrgyzstan", "KG", 417, "ky,ru") },
            { new CountryInfo("Lao People's Democratic Republic", "LA", 418, "lo") },
            { new CountryInfo("Latvia", "LV", 428, "lv") },
            { new CountryInfo("Lebanon", "LB", 422, "ar") },
            { new CountryInfo("Lesotho", "LS", 426, "en,st") },
            { new CountryInfo("Liberia", "LR", 430, "en,vai,vai") },
            { new CountryInfo("Libya", "LY", 434, "ar") },
            { new CountryInfo("Liechtenstein", "LI", 438, "de,gsw") },
            { new CountryInfo("Lithuania", "LT", 440, "lt") },
            { new CountryInfo("Luxembourg", "LU", 442, "de,fr,lb,pt") },
            { new CountryInfo("Macao", "MO", 446, "en,pt,zh,zh") },
            { new CountryInfo("Macedonia, the former Yugoslav Republic of", "MK", 807, "mk,sq") },
            { new CountryInfo("Madagascar", "MG", 450, "en,fr,mg") },
            { new CountryInfo("Malawi", "MW", 454, "en") },
            { new CountryInfo("Malaysia", "MY", 458, "en,ms,ta") },
            { new CountryInfo("Maldives", "MV", 462, "dv") },
            { new CountryInfo("Mali", "ML", 466, "bm,fr,khq,ses") },
            { new CountryInfo("Malta", "MT", 470, "en,mt") },
            { new CountryInfo("Marshall Islands", "MH", 584, "en") },
            { new CountryInfo("Martinique", "MQ", 474, "fr") },
            { new CountryInfo("Mauritania", "MR", 478, "ar,ff,fr") },
            { new CountryInfo("Mauritius", "MU", 480, "en,fr,mfe") },
            { new CountryInfo("Mayotte", "YT", 175, "fr") },
            { new CountryInfo("Mexico", "MX", 484, "es") },
            { new CountryInfo("Micronesia, Federated States of", "FM", 583, "en") },
            { new CountryInfo("Moldova, Republic of", "MD", 498, "ro,ru") },
            { new CountryInfo("Monaco", "MC", 492, "fr") },
            { new CountryInfo("Mongolia", "MN", 496, "mn,mn") },
            { new CountryInfo("Montenegro", "ME", 499, "sr,sr") },
            { new CountryInfo("Montserrat", "MS", 500, "en") },
            { new CountryInfo("Morocco", "MA", 504, "ar,fr,shi,shi,tzm,tzm,tzm,zgh") },
            { new CountryInfo("Mozambique", "MZ", 508, "mgh,pt,seh") },
            { new CountryInfo("Myanmar", "MM", 104, "my") },
            { new CountryInfo("Namibia", "NA", 516, "af,en,naq") },
            { new CountryInfo("Nauru", "NR", 520, "en") },
            { new CountryInfo("Nepal", "NP", 524, "ne") },
            { new CountryInfo("Netherlands", "NL", 528, "en,fy,nds,nl") },
            { new CountryInfo("New Caledonia", "NC", 540, "fr") },
            { new CountryInfo("New Zealand", "NZ", 554, "en,mi") },
            { new CountryInfo("Nicaragua", "NI", 558, "es") },
            { new CountryInfo("Niger", "NE", 562, "dje,fr,ha,twq") },
            { new CountryInfo("Nigeria", "NG", 566, "bin,en,ff,ha,ibb,ig,kr,yo") },
            { new CountryInfo("Niue", "NU", 570, "en") },
            { new CountryInfo("Norfolk Island", "NF", 574, "en") },
            { new CountryInfo("Northern Mariana Islands", "MP", 580, "en") },
            { new CountryInfo("Norway", "NO", 578, "nb,nn,se,sma,smj") },
            { new CountryInfo("Oman", "OM", 512, "ar") },
            { new CountryInfo("Pakistan", "PK", 586, "en,pa,sd,ur") },
            { new CountryInfo("Palau", "PW", 585, "en") },
            { new CountryInfo("Palestinian Territory, Occupied", "PS", 275, "ar") },
            { new CountryInfo("Panama", "PA", 591, "es") },
            { new CountryInfo("Papua New Guinea", "PG", 598, "en") },
            { new CountryInfo("Paraguay", "PY", 600, "es,gn") },
            { new CountryInfo("Peru", "PE", 604, "es,quz") },
            { new CountryInfo("Philippines", "PH", 608, "en,es,fil") },
            { new CountryInfo("Pitcairn", "PN", 612, "en") },
            { new CountryInfo("Poland", "PL", 616, "pl") },
            { new CountryInfo("Portugal", "PT", 620, "pt") },
            { new CountryInfo("Puerto Rico", "PR", 630, "en,es") },
            { new CountryInfo("Qatar", "QA", 634, "ar") },
            { new CountryInfo("R‚union", "RE", 638, "fr") },
            { new CountryInfo("Romania", "RO", 642, "ro") },
            { new CountryInfo("Russian Federation", "RU", 643, "ba,ce,cu,os,ru,sah,tt") },
            { new CountryInfo("Rwanda", "RW", 646, "en,fr,rw") },
            { new CountryInfo("Saint Barth‚lemy", "BL", 652, "fr") },
            { new CountryInfo("Saint Helena, Ascension and Tristan da Cunha", "SH", 654, "en") },
            { new CountryInfo("Saint Kitts and Nevis", "KN", 659, "en") },
            { new CountryInfo("Saint Lucia", "LC", 662, "en") },
            { new CountryInfo("Saint Martin (French part)", "MF", 663, "fr") },
            { new CountryInfo("Saint Pierre and Miquelon", "PM", 666, "fr") },
            { new CountryInfo("Saint Vincent and the Grenadines", "VC", 670, "en") },
            { new CountryInfo("Samoa", "WS", 882, "en") },
            { new CountryInfo("San Marino", "SM", 674, "it") },
            { new CountryInfo("Sao Tome and Principe", "ST", 678, "pt") },
            { new CountryInfo("Saudi Arabia", "SA", 682, "ar") },
            { new CountryInfo("Senegal", "SN", 686, "dyo,ff,fr,wo") },
            { new CountryInfo("Serbia", "RS", 688, "sr,sr") },
            { new CountryInfo("Seychelles", "SC", 690, "en,fr") },
            { new CountryInfo("Sierra Leone", "SL", 694, "en") },
            { new CountryInfo("Singapore", "SG", 702, "en,ms,ta,zh") },
            { new CountryInfo("Sint Maarten (Dutch part)", "SX", 534, "en,nl") },
            { new CountryInfo("Slovakia", "SK", 703, "sk") },
            { new CountryInfo("Slovenia", "SI", 705, "en,sl") },
            { new CountryInfo("Solomon Islands", "SB", 90, "en") },
            { new CountryInfo("Somalia", "SO", 706, "ar,so") },
            { new CountryInfo("South Africa", "ZA", 710, "af,en,nr,nso,ss,st,tn,ts,ve,xh,zu") },
            { new CountryInfo("South Georgia and the South Sandwich Islands", "GS", 239, "") },
            { new CountryInfo("South Sudan", "SS", 728, "ar,en,nus") },
            { new CountryInfo("Spain", "ES", 724, "ast,ca,es,eu,gl") },
            { new CountryInfo("Sri Lanka", "LK", 144, "si,ta") },
            { new CountryInfo("Sudan", "SD", 729, "ar,en") },
            { new CountryInfo("Suriname", "SR", 740, "nl") },
            { new CountryInfo("Svalbard and Jan Mayen", "SJ", 744, "nb") },
            { new CountryInfo("Swaziland", "SZ", 748, "en,ss") },
            { new CountryInfo("Sweden", "SE", 752, "en,se,sma,smj,sv") },
            { new CountryInfo("Switzerland", "CH", 756, "de,en,fr,gsw,it,pt,rm,wae") },
            { new CountryInfo("Syrian Arab Republic", "SY", 760, "ar,fr,syr") },
            { new CountryInfo("Taiwan, Province of China", "TW", 158, "zh") },
            { new CountryInfo("Tajikistan", "TJ", 762, "tg") },
            { new CountryInfo("Tanzania, United Republic of", "TZ", 834, "asa,bez,en,jmc,kde,ksb,lag,mas,rof,rwk,sbp,sw,vun") },
            { new CountryInfo("Thailand", "TH", 764, "th") },
            { new CountryInfo("Timor-Leste", "TL", 626, "pt") },
            { new CountryInfo("Togo", "TG", 768, "ee,fr") },
            { new CountryInfo("Tokelau", "TK", 772, "en") },
            { new CountryInfo("Tonga", "TO", 776, "en,to") },
            { new CountryInfo("Trinidad and Tobago", "TT", 780, "en") },
            { new CountryInfo("Tunisia", "TN", 788, "ar,fr") },
            { new CountryInfo("Turkey", "TR", 792, "tr") },
            { new CountryInfo("Turkmenistan", "TM", 795, "tk") },
            { new CountryInfo("Turks and Caicos Islands", "TC", 796, "en") },
            { new CountryInfo("Tuvalu", "TV", 798, "en") },
            { new CountryInfo("Uganda", "UG", 800, "cgg,en,lg,nyn,sw,teo,xog") },
            { new CountryInfo("Ukraine", "UA", 804, "ru,uk") },
            { new CountryInfo("United Arab Emirates", "AE", 784, "ar") },
            { new CountryInfo("United Kingdom", "GB", 826, "cy,en,gd,kw") },
            { new CountryInfo("United States", "US", 840, "en,es,chr,haw,lkt") },
            { new CountryInfo("United States Minor Outlying Islands", "UM", 581, "en") },
            { new CountryInfo("Uruguay", "UY", 858, "es") },
            { new CountryInfo("Uzbekistan", "UZ", 860, "uz,uz") },
            { new CountryInfo("Vanuatu", "VU", 548, "en,fr") },
            { new CountryInfo("Venezuela, Bolivarian Republic of", "VE", 862, "es") },
            { new CountryInfo("Viet Nam", "VN", 704, "vi") },
            { new CountryInfo("Virgin Islands, British", "VG", 92, "en") },
            { new CountryInfo("Virgin Islands, U.S.", "VI", 850, "en") },
            { new CountryInfo("Wallis and Futuna", "WF", 876, "fr") },
            { new CountryInfo("Western Sahara", "EH", 732, "") },
            { new CountryInfo("Yemen", "YE", 887, "ar") },
            { new CountryInfo("Zambia", "ZM", 894, "bem,en") },
            { new CountryInfo("Zimbabwe", "ZW", 716, "en,nd,sn") }
        };

        internal CountryInfo(string fullName, string twoLetterCode, int numericCode, string twoLetterLanguageCode) {
            Name = fullName;
            TwoLetterCode = twoLetterCode;
            NumericCode = numericCode;
            TwoLetterLanguageCode = string.IsNullOrWhiteSpace(twoLetterLanguageCode) ? null : twoLetterLanguageCode;
        }

        public string Name { get; private set; }
        public string TwoLetterCode { get; private set; }
        public string TwoLetterLanguageCode { get; private set; }
        public int NumericCode { get; private set; }
        public string Locale => TwoLetterLanguageCode != null ? $"{TwoLetterLanguageCode?.Split(',')[0]}-{TwoLetterCode}" : null;
        public override string ToString() => $"({TwoLetterCode}) {Name}";

        public static CountryInfo GetCountryByNumericCode(int code) {
            var data = Countries.FirstOrDefault(cd => cd.NumericCode == code);

            if (data == null) {
                throw new ArgumentException(string.Format("{0} is an invalid numeric countrycode!", code), nameof(code));
            }

            return data;
        }

        public static CountryInfo GetCountryByNameOrCode(string nameOrTwoLetterCode) {
            var data = Countries.FirstOrDefault(cd => string.Equals(cd.Name, nameOrTwoLetterCode, StringComparison.CurrentCultureIgnoreCase) || string.Equals(cd.TwoLetterCode, nameOrTwoLetterCode, StringComparison.CurrentCultureIgnoreCase));

            if (data == null) {
                throw new ArgumentException($"CountryData with name or two letter code {nameOrTwoLetterCode} does not exist!", nameof(nameOrTwoLetterCode));
            }

            return data;
        }

        public static bool TryGetCountryByNameOrCode(string nameOrTwoLetterCode, out CountryInfo countryInfo) {
            var success = true;
            countryInfo = default(CountryInfo);

            try {
                if (!string.IsNullOrEmpty(nameOrTwoLetterCode)) {
                    countryInfo = GetCountryByNameOrCode(nameOrTwoLetterCode.ToUpper());
                }
            } catch {
                success = false;
            }

            return success;
        }

        public static bool ValidCountryNameOrCode(string nameOrTwoLetterCode) => Countries
            .Where(ci => string.Equals(ci.Name, nameOrTwoLetterCode, StringComparison.CurrentCultureIgnoreCase) || string.Equals(ci.TwoLetterCode, nameOrTwoLetterCode, StringComparison.CurrentCultureIgnoreCase))
            .Any();
    }
}