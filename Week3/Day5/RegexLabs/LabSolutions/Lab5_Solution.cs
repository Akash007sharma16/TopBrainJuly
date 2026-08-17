// ──────────────────────────────────────────────────────────────────────────────
// Lab 5 Reference Solution
// Capstone – Log File Parser
// ──────────────────────────────────────────────────────────────────────────────
using System.Text.RegularExpressions;

// LogEntry, LogParser, and Lab5 are already defined in Lab5.cs.
// This file exists as an annotated reference only.

/*
KEY DECISIONS:
 - ParseLog uses a single named-group pattern with RegexOptions.Multiline so one
   Regex.Matches call handles the entire raw log in one pass.
 - RedactErrorCodes processes line by line to avoid a look-behind that spans
   multiple lines; this keeps the code readable and the look-behind lightweight.
 - FindErrorsInRange relies on simple string comparison, which is correct here
   because the HH:mm:ss format is fixed-width and zero-padded.

EXPECTED OUTPUT (matches Lab5.Run()):
  Parsed 6 entries.
  Summary: INFO: 3, WARN: 1, ERROR: 2

  --- Redacted log ---
  2026-08-14 09:15:00 INFO  Service started
  2026-08-14 09:16:12 WARN  Disk usage high
  2026-08-14 09:17:45 ERROR Request failed code=###
  2026-08-14 09:18:03 INFO  Request completed
  2026-08-14 09:19:22 ERROR Upstream error code=###
  2026-08-14 09:20:00 INFO  Shutdown complete
*/
