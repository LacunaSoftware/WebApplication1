﻿using System;
using Lacuna.Pki.Stores;
using System.Reflection;
using System.Web;
using Lacuna.Pki;

namespace WebApplication1.Service
{
    public class Util
    {
		
	public static string PkiLicensePath
		{
			get
			{
				var assemblyPath = Assembly.GetExecutingAssembly().CodeBase;
				if (assemblyPath.StartsWith("file://", StringComparison.OrdinalIgnoreCase))
				{
					assemblyPath = assemblyPath.Substring(8);
				}
				return Path.Combine("C://Users//danie//Desktop//LacunaPkiLicense.config");
			}
		}
	public static INonceStore GetNonceStore()
		{
	
			return new FileSystemNonceStore("C://Users//danie//Desktop");
		}

	public static ITrustArbitrator GetTrustArbitrator()
	{

		var trustArbitrator = new LinkedTrustArbitrator(TrustArbitrators.PkiBrazil, TrustArbitrators.Windows);

		var lacunaRoot = Lacuna.Pki.PKCertificate.Decode(Convert.FromBase64String("MIIGGTCCBAGgAwIBAgIBATANBgkqhkiG9w0BAQ0FADBfMQswCQYDVQQGEwJCUjETMBEGA1UECgwKSUNQLUJyYXNpbDEdMBsGA1UECwwUTGFjdW5hIFNvZnR3YXJlIC0gTFMxHDAaBgNVBAMME0xhY3VuYSBSb290IFRlc3QgdjEwHhcNMTUwMTE2MTk1MjQ1WhcNMjUwMTE2MTk1MTU1WjBfMQswCQYDVQQGEwJCUjETMBEGA1UECgwKSUNQLUJyYXNpbDEdMBsGA1UECwwUTGFjdW5hIFNvZnR3YXJlIC0gTFMxHDAaBgNVBAMME0xhY3VuYSBSb290IFRlc3QgdjEwggIiMA0GCSqGSIb3DQEBAQUAA4ICDwAwggIKAoICAQCDm5ey0c4ij8xnDnV2EBATjJbZjteEh8BBiGtVx4dWpXbWQ6hEw8E28UyLsF6lCM2YjQge329g7hMANnrnrNCvH1ny4VbhHMe4eStiik/GMTzC79PYS6BNfsMsS6+W18a45eyi/2qTIHhJYN8xS4/7pAjrVpjL9dubALdiwr26I3a4S/h9vD2iKJ1giWnHU74ckVp6BiRXrz2ox5Ps7p420VbVU6dTy7QR2mrhAus5va9VeY1LjvCH9S9uSf6kt+HP1Kj7hlOOlcnluXmuD/IN68/CQeC+dLOr0xKmDvYv7GWluXhxpUZmh6NaLzSGzGNACobOezKmby06s4CvsmMKQuZrTx113+vJkYSgI2mBN5v8LH60DzuvIhMvDLWPZCwfnyGCNHBwBbdgzBWjsfuSFJyaKdJLmpu5OdWNOLjvexqEC9VG83biYr+8XMiWl8gUW8SFqEpNoLJ59nwsRf/R5R96XTnG3mdVugcyjR9xe/og1IgJFf9Op/cBgCjNR/UAr+nizHO3Q9LECnu1pbTtGZguGDMABc+/CwKyxirwlRpiu9DkdBlNRgdd5IgDkcgFkTjmA41ytU0LOIbxpKHn9/gZCevq/8CyMa61kgjzg1067BTslex2xUZm44oVGrEdx5kg/Hz1Xydg4DHa4qlG61XsTDJhM84EvnJr3ZTYOwIDAQABo4HfMIHcMDwGA1UdIAQ1MDMwMQYFYEwBAQAwKDAmBggrBgEFBQcCARYaaHR0cDovL2xhY3VuYXNvZnR3YXJlLmNvbS8wOwYDVR0fBDQwMjAwoC6gLIYqaHR0cDovL2NhdGVzdC5sYWN1bmFzb2Z0d2FyZS5jb20vY3Jscy9yb290MB8GA1UdIwQYMBaAFPtdXjCI7ZOfGUg8mrCoEw9z9zywMB0GA1UdDgQWBBT7XV4wiO2TnxlIPJqwqBMPc/c8sDAPBgNVHRMBAf8EBTADAQH/MA4GA1UdDwEB/wQEAwIBBjANBgkqhkiG9w0BAQ0FAAOCAgEAN/b8hNGhBrWiuE67A8kmom1iRUl4b8FAA8PUmEocbFv/BjLpp2EPoZ0C+I1xWT5ijr4qcujIMsjOCosmv0M6bzYvn+3TnbzoZ3tb0aYUiX4ZtjoaTYR1fXFhC7LJTkCN2phYdh4rvMlLXGcBI7zA5+Ispm5CwohcGT3QVWun2zbrXFCIigRrd3qxRbKLxIZYS0KW4X2tetRMpX6DPr3MiuT3VSO3WIRG+o5Rg09L9QNXYQ74l2+1augJJpjGYEWPKzHVKVJtf1fj87HN/3pZ5Hr2oqDvVUIUGFRj7BSel9BgcgVaWqmgTMSEvQWmjq0KJpeqWbYcXXw8lunuJoENEItv+Iykv3NsDfNXgS+8dXSzTiV1ZfCdfAjbalzcxGn522pcCceTyc/iiUT72I3+3BfRKaMGMURu8lbUMxd/38Xfut3Kv5sLFG0JclqD1rhI15W4hmvb5bvol+a/WAYT277jwdBO8BVSnJ2vvBUzH9KAw6pAJJBCGw/1dZkegLMFibXdEzjAW4z7wyx2c5+cmXzE/2SFV2cO3mJAtpaO99uwLvj3Y3quMBuIhDGD0ReDXNAniXXXVPfE96NUcDF2Dq2g8kj+EmxPy6PGZ15p1XZO1yiqsGEVreIXqgcU1tPUv8peNYb6jHTHuUyXGTzbsamGZFEDsLG7NRxg0eZWP1w="));
		trustArbitrator.Add(new TrustedRoots(lacunaRoot));

		var solutiTestRoot = Lacuna.Pki.PKCertificate.Decode(Convert.FromBase64String("MIIFqjCCA5KgAwIBAgIIS9uixHDoFa8wDQYJKoZIhvcNAQENBQAwPTELMAkGA1UEBhMCQlIxEzARBgNVBAoTCklDUC1CcmFzaWwxGTAXBgNVBAMTEEFDIFJBSVogdGVzdGUgdjIwHhcNMTQwMjA0MTkwMDU3WhcNMjQwMjA0MTkwMDU3WjA9MQswCQYDVQQGEwJCUjETMBEGA1UEChMKSUNQLUJyYXNpbDEZMBcGA1UEAxMQQUMgUkFJWiB0ZXN0ZSB2MjCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAKq/E45POudJct3XbsGSfeidHQmP3SAgKVt7URE3erLncOoIwEdgm2++cnSzuTqNSHo9F27eMtvvpsoizLUwEcZEwtkocijiN7FSLigdaJ/Ulb8ZNUcsvOHL82p+allTUCP9cJjmrkN6HwwtxfQGirvmP2Kq19mNJlJumTmD3w4Ar7pX1mi4kK7Fokud/000wrXydUfVcN3VWH2Nv0pioY+olsHi/AUXAfdlO4V7jtrWh3ZIlZJQIsZ0WNOS9NLxr4q7urubl2K23NAEVl5CCvVC3RJLCZdgH307y9fa7ajvKvrCls05T74aPTm0CoCVSQxP+L6UUIpz9U3aDTOILSfk8kx+aCN7K7XLZ5fG7ncIEy0JPgIv/UNftyXRrp4s+srG6oXR4fBf0komQ8UAk5tvdS3KNlfN/V4oLTnyQdK/hhH42hpCzHNlGTwomJKQnszFlozy1XuUYi0NuYZya+pqmG/GUkIDBoq6++W7rBHvZtjR1kjW9JkUTF12AvwwYXPWkUMJGWBUaWoyiSOf8fGoMp6aedhGBtGRFDTBFpNCBEj0lRVc2N0k+irOdTwsvrwhKQkeQhehULtNInsXfpUFmKKtfbQCym2ejmtXU4pCKI+3D2dc182Max+KIq3kAbK1FsjtSAtYUm5qlnWAYPufjWh60S1PS7ydu8WS+uyfAgMBAAGjga0wgaowHQYDVR0OBBYEFEc20cVEy8tlLaDGBYBZWVp2exxtMA8GA1UdEwEB/wQFMAMBAf8wHwYDVR0jBBgwFoAURzbRxUTLy2UtoMYFgFlZWnZ7HG0wRwYDVR0fBEAwPjA8oDqgOIY2aHR0cDovL2NjZC5hY3NvbHV0aS5jb20uYnIvdGVzdGVzL2FjLXJhaXotdGVzdGUtdjIuY3JsMA4GA1UdDwEB/wQEAwIBBjANBgkqhkiG9w0BAQ0FAAOCAgEAmhkzT4DC+5jRYkUuerr+jU6F4DNS+dxdLPFvIDVadLX1VmZ4SfNLiLKDyUZiP8DG0UAoa0lOjb6H8jLJV13bhKmQLYLOgjzAFOjXuTp4PjlbJ686J1f4dJV25ocNDjkX/z+I8OdaHjeuuv6lE5TjqztK18Y1wULFEGDgU7W81FyMOJB7+Ft1M88H+WVdkhY4nP4lHjCo4+vlq33WPwH9ov3GBGp74nTZko8AoygN2XB8csTC99LRlkmzQAZVsuBHM2GA0RGewv5YcLTc7cXb/JoIcZdWM2DepM3jAyBe3FLvaFgL/tPwOFNoppt0t0ctt0RMqOLRSncuHze75a1spjyNvAAfhy7uyn1+2+Vre7hVQnE8os6fmM0N/r5QCiQxOb7s08FwM2cUIHQ93Chxgjdil0RS9drUI2TQgHxkaGxQm1ufI4sUFj+R8e++P40sLWVjSMPU9jH3F8Stp/a+OCNao5wcr3OusmMUzmK6lEn7WUP0tJlWisoHlkpyWRiJO2LItwcOx4bggDGzSb0OmxP2SQEAx8yGbZ5HSMy655vp7oNyvj7336+1oxNPpC4a6rNwcLwPD+NwqO3U5VfqdzaxzIco8IRbuaoe2u/UXxuUwOUuwWvEOkbvdER9hdvhTcaN32mmA0Kect6WnDtU8JBxb7O8UQHjah7b6at9KWg="));
		trustArbitrator.Add(new TrustedRoots(solutiTestRoot));

		return trustArbitrator;
	}
	}
}

