import importlib.util
from pathlib import Path
import tempfile
import unittest
import zipfile

spec = importlib.util.spec_from_file_location("verifier", Path(__file__).with_name("verify-release-package.py"))
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)

class ReleasePackageTests(unittest.TestCase):
    def test_version_and_every_declared_framework_are_required(self):
        with tempfile.TemporaryDirectory() as directory:
            root = Path(directory)
            project = root / "library.csproj"
            project.write_text("<Project><PropertyGroup><TargetFrameworks>net48;net8.0;net10.0</TargetFrameworks></PropertyGroup></Project>")
            package = root / "library.nupkg"
            def write(version, targets):
                with zipfile.ZipFile(package, "w") as z:
                    z.writestr("library.nuspec", f'<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd"><metadata><version>{version}</version></metadata></package>')
                    for target in targets:
                        z.writestr(f"lib/{target}/OoplesFinance.YahooFinanceAPI.dll", b"test")
            write("1.7.1", ["net48", "net8.0", "net10.0"])
            module.verify(root, "1.7.1", project)
            with self.assertRaisesRegex(ValueError, "version"):
                module.verify(root, "1.7.2", project)
            write("1.7.1", ["net10.0"])
            with self.assertRaisesRegex(ValueError, "net48"):
                module.verify(root, "1.7.1", project)
            package.unlink()
            with self.assertRaisesRegex(ValueError, "exactly one"):
                module.verify(root, "1.7.1", project)

if __name__ == "__main__":
    unittest.main()
