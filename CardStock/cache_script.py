import re
from pathlib import Path

TEXT_CACHE = """private string cache;

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
        r'^([ \t]*)public partial class \w+ : ParserRuleContext[ \t]*\r?\n[ \t]*\{',
        re.MULTILINE
    )

    matches = list(pattern.finditer(text))
    for i in reversed(range(len(matches))):
        match = matches[i]
        indent = match.group(1)

        start = match.end()
        end = matches[i + 1].start() if i + 1 < len(matches) else len(text)

        class_body = text[start:end]

        if "private string cache;" in class_body:
            continue

        code = "\n" + "\n".join(
            indent + "\t" + line
            for line in TEXT_CACHE.splitlines()
        ) + "\n"

        text = text[:start] + code + text[start:]

    path.write_text(text)


if __name__ == "__main__":
    process(Path("RecycleParser.cs"))