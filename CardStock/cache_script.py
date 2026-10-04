import re
import sys
from pathlib import Path

TEXT_CACHE = """        private string cache;

        public override string GetText()
        {
            if (cache is null)
            {
                cache = base.GetText();
            }

            return cache;
        }
"""

def process(path: Path):
    text = path.read_text()

    pattern = re.compile(
        r'(^[ \t]*)public partial class \w+ : ParserRuleContext\s*\{',
        re.MULTILINE
    )

    matches = list(pattern.finditer(text))

    for match in reversed(matches):
        class_start = match.end()
        indent = match.group(1)

        if re.search(r'\bprivate string cache;', text[class_start:]):
            continue

        print("found")

        code = "\n" + "\n".join(indent + line for line in TEXT_CACHE.splitlines()) + "\n"

        text = text[:class_start] + code + text[class_start:]

    path.write_text(text)

if __name__ == "__main__":
    process(Path("RecycleParser.cs"))