// CodeMirror, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: http://codemirror.net/LICENSE

(function(mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/codemirror"));
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/codemirror"], mod);
  else // Plain browser env
    mod(CodeMirror);
})(function(CodeMirror) {
  "use strict";

  var noOptions = {};
  var nonWS = /[^\s\u00a0]/;
  var Pos = CodeMirror.Pos;

  function firstNonWS(str) {
    var found = str.search(nonWS);
    return found == -1 ? 0 : found;
  }

  CodeMirror.commands.toggleComment = function(cm) {
    cm.toggleComment();
  };

  CodeMirror.defineExtension("toggleComment", function(options) {
    if (!options) options = noOptions;
    var cm = this;
    var minLine = Infinity, ranges = this.listSelections(), mode = null;
    for (var i = ranges.length - 1; i >= 0; i--) {
      var from = ranges[i].from(), to = ranges[i].to();
      if (from.line >= minLine) continue;
      if (to.line >= minLine) to = Pos(minLine, 0);
      minLine = from.line;
      if (mode == null) {
        if (cm.uncomment(from, to, options)) mode = "un";
        else { cm.lineComment(from, to, options); mode = "line"; }
      } else if (mode == "un") {
        cm.uncomment(from, to, options);
      } else {
        cm.lineComment(from, to, options);
      }
    }
  });

  // Rough heuristic to try and detect lines that are part of multi-line string
  function probablyInsideString(cm, pos, line) {
    return /\bstring\b/.test(cm.getTokenTypeAt(Pos(pos.line, 0))) && !/^[\'\"`]/.test(line)
  }

  CodeMirror.defineExtension("lineComment", function(from, to, options) {
    if (!options) options = noOptions;
    var self = this, mode = self.getModeAt(from);
    var firstLine = self.getLine(from.line);
    if (firstLine == null || probablyInsideString(self, from, firstLine)) return;

    var commentString = options.lineComment || mode.lineComment;
    if (!commentString) {
      if (options.blockCommentStart || mode.blockCommentStart) {
        options.fullLines = true;
        self.blockComment(from, to, options);
      }
      return;
    }

    var end = Math.min(to.ch != 0 || to.line == from.line ? to.line + 1 : to.line, self.lastLine() + 1);
    var pad = options.padding == null ? " " : options.padding;
    var blankLines = options.commentBlankLines || from.line == to.line;

    self.operation(function() {
      if (options.indent) {
        var baseString = null;
        for (var i = from.line; i < end; ++i) {
          var line = self.getLine(i);
          var whitespace = line.slice(0, firstNonWS(line));
          if (baseString == null || baseString.length > whitespace.length) {
            baseString = whitespace;
          }
        }
        for (var i = from.line; i < end; ++i) {
          var line = self.getLine(i), cut = baseString.length;
          if (!blankLines && !nonWS.test(line)) continue;
          if (line.slice(0, cut) != baseString) cut = firstNonWS(line);
          self.replaceRange(baseString + commentString + pad, Pos(i, 0), Pos(i, cut));
        }
      } else {
        for (var i = from.line; i < end; ++i) {
          if (blankLines || nonWS.test(self.getLine(i)))
            self.replaceRange(commentString + pad, Pos(i, 0));
        }
      }
    });
  });

  CodeMirror.defineExtension("blockComment", function(from, to, options) {
    if (!options) options = noOptions;
    var self = this, mode = self.getModeAt(from);
    var startString = options.blockCommentStart || mode.blockCommentStart;
    var endString = options.blockCommentEnd || mode.blockCommentEnd;
    if (!startString || !endString) {
      if ((options.lineComment || mode.lineComment) && options.fullLines != false)
        self.lineComment(from, to, options);
      return;
    }
    if (/\bcomment\b/.test(self.getTokenTypeAt(Pos(from.line, 0)))) return

    var end = Math.min(to.line, self.lastLine());
    if (end != from.line && to.ch == 0 && nonWS.test(self.getLine(end))$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��f$�h�����eԎ���H���`ݶf{�Fo�Y���@00uMb�z-��XI$&�gf���7Ӵ�u|'K.�oP
P���F�.��o��9B<~. ����[����<٭�$�����{1�A��.�bKx�L������'�u8n5���e ,]�H����V��Ww�$�C�el��|zys��K�i-�q�ݬbk,wnG��;�� ~�e�r͒���~'1`V⦫�-*[��L�K�'2@����仪��n���2�N� �ƶ�G���i/U��'E�@�`H��;J�������+J�n#���6ڴ�ĹG���N�G�'�Z!�����Wi��NJ�@���A��Z|�[��$q}i�ҷ�QbtTEC$��m��mo�L�D��;�%g�?w��ŷ���ovH0��a�5��*�ؒ��l͛�S�iy�r�O7����%L]��%���hk ����>v1�HB������d\�(eoIx�>3�6BS%���(
��