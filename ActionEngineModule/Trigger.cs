namespace ActionEngineModule
{
    public class Trigger
    {
        public string Token { get; set; }
        public string TopicExpression { get; set; }
        public string ContentExpression { get; set; }
        public string TopicExpressionDialect { get; set; }
        public string ContentExpressionDialect { get; set; }
        public string[] ActionTokens { get; set; }
    }
}
