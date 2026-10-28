"""Validate a release package against the tagged project's declared targets."""
from pathlib import Path
import sys
import xml.etree.ElementTree as ET
import zipfile

def verify(directory, version, project=Path("src/OoplesFinance.YahooFinanceAPI.csproj")):
    targets = ET.parse(project).findtext(".//TargetFrameworks").split(";")
    packages = list(Path(directory).glob("*.nupkg"))
    if len(packages) != 1:
        raise ValueError("Expected exactly one NuGet package")
    with zipfile.ZipFile(packages[0]) as package:
        nuspec = [p for p in package.namelist() if p.endswith(".nuspec")]
        if len(nuspec) != 1:
            raise ValueError("Expected one package manifest")
        metadata = ET.fromstring(package.read(nuspec[0]))
        actual = metadata.findtext(".//{*}version")
        if actual != version:
            raise ValueError(f"Package version {actual!r} does not match release {version!r}")
        for target in targets:
            expected = f"lib/{target}/OoplesFinance.YahooFinanceAPI.dll"
            if expected not in package.namelist():
                raise ValueError(f"Missing package asset: {expected}")
    print(f"Verified {packages[0].name}: version {version}; targets {', '.join(targets)}")

if __name__ == "__main__":
    verify(sys.argv[1], sys.argv[2])
