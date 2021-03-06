// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System.Diagnostics;

public class CustomSignatures {

    public static Signature ForFunction(Signature s, string cefName, CefConfigData cefConfig) {
        if(cefName.Contains("::get_") && s.Arguments.Length == 2) {
            if(s.ReturnType.IsVoid) {
                if(s.Arguments[1].ArgumentType.Name.StartsWith("cef_string_list") || s.Arguments[1].ArgumentType.Name.StartsWith("cef_string_m")) {
                    return new StringCollectionAsRetvalSignature(s);
                }
            }
        }

        if(cefConfig.CountFunction != null && s.Arguments.Length == 3 && s.ReturnType.IsVoid) {
            if(s.Arguments[2].ArgumentType.IsCefStructPtrPtrType) {
                return new StructArrayGetterSignature(s, cefConfig.CountFunction);
            }
        }

        switch(cefName) {
            case "cef_browser::get_frame_identifiers":
                return new GetFrameIdentifiersSignature(s);

            case "cef_v8handler::execute":
                return new CefV8HandlerExecuteSignature(s);

            case "cef_print_settings::get_page_ranges":
                return new GetPageRangesSignature(s, 2, 1);

        }

        for(var i = 0; i <= s.Arguments.Length - 1; i++) {

            var suffixLength = 0;
            if(s.Arguments[i].VarName.EndsWith("_count")) suffixLength = 6;
            if(s.Arguments[i].VarName.EndsWith("Count")) suffixLength = 5;

            if(suffixLength > 0) {
                var arrName = s.Arguments[i].VarName.Substring(0, s.Arguments[i].VarName.Length - suffixLength);
                int arrayArgIndex = -1;
                if(i > 0 && s.Arguments[i - 1].VarName.StartsWith(arrName)) {
                    arrayArgIndex = i - 1;
                } else if(i < s.Arguments.Length - 1 && s.Arguments[i + 1].VarName.StartsWith(arrName)) {
                    arrayArgIndex = i + 1;
                } else {
                }
                if(arrayArgIndex > 0) {
                    var arrayType = s.Arguments[arrayArgIndex].ArgumentType;
                    if(arrayType.IsCefStructPtrType) {
                        Debug.Assert(arrayType.AsCefStructPtrType.Struct.ClassBuilder.Category == StructCategory.Values);
                        return new SignatureWithStructArray(s, arrayArgIndex, i);
                    } else if(arrayType.IsCefStructPtrPtrType) {
                        return new SignatureWithStructPtrArray(s, arrayArgIndex, i);
                    }
                }
            }
        }

        return null;
    }
}