using System;
using System.Collections.Generic;
public class Json{
	public enum DataType{
		JsonDict,JsonString,JsonArray,JsonNum
	};


	public String stringValue = "";
	public List<Json> childArray = new List<Json>();
	public Dictionary<String,Json> childKey = new Dictionary<String,Json>();
	public DataType jsonType = Json.DataType.JsonDict;
	public Json(String input){
		input = input.Trim();
		int curIdx = 1;
		int startIdx = 1;
		if (input.Substring (0, 1) == "\"") {
			this.stringValue = input.Substring (1, input.Length - 1);
			return;
		}
		if (input.Substring (0, 1) == "[") {
			this.jsonType = DataType.JsonArray;
			String[] res = input.Substring (0, input.Length - 1).Split (',');
			foreach (var s in res){
				childArray.Add (new Json (s));
			}
			return;
		}
		while (curIdx < input.Length){
			++curIdx;
			if (input.Substring(curIdx,1) == ":"){
				String key = input.Substring(startIdx,curIdx - startIdx).Trim();
				++curIdx;
				char type  = ' ';
				while (input.Substring(curIdx,1) != "[" && input.Substring(curIdx,1) != "{"){
					++curIdx;
				}
				startIdx = curIdx;
				type = input.Substring(curIdx,1).ToCharArray()[0];
				char closeType = ' ';
				if (type == '['){
					closeType = ']';
				}
				else{
					closeType = '}';
				}
				int subCount = 0;
				while (input.Substring(curIdx,1) != closeType.ToString() || subCount != 0){
					String curr = input.Substring(curIdx,1);
					if (curr == type.ToString()){
						++subCount;
					}
					else if (curr == closeType.ToString()){
						--subCount;
					}
					++curIdx;
				}
				Json child = new Json(input.Substring(startIdx,curIdx - startIdx).Trim());
				childKey.Add(key,child);
				
				
			}
		}
	}
	public override String ToString(){
		return "";
	}
}