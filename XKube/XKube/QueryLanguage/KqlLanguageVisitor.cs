using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using k8s.KubeConfigModels;
using XKube.Grammar;

namespace XKube.QueryLanguage;
public class KqlLanguageVisitor : KqlBaseVisitor<string>
{
    public override string VisitTop(KqlParser.TopContext context)
    {
        var table = context.GetText();
        return base.VisitTop(context);
    }

    public override string VisitQuery(KqlParser.QueryContext context)
    {
        // pods | where contains "etcd"
        var table = context.GetText();
        return base.VisitQuery(context);
    }

    public override string VisitStatement(KqlParser.StatementContext context)
    {
        // pods | where contains "etcd"
        var table = context.GetText();
        return base.VisitStatement(context);
    }

    public override string VisitAliasDatabaseStatement(KqlParser.AliasDatabaseStatementContext context)
    {
        var table = context.GetText();
        return base.VisitAliasDatabaseStatement(context);
    }

    public override string VisitLetStatement(KqlParser.LetStatementContext context)
    {
        var table = context.GetText();
        return base.VisitLetStatement(context);
    }

    public override string VisitLetVariableDeclaration(KqlParser.LetVariableDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitLetVariableDeclaration(context);
    }

    public override string VisitLetFunctionDeclaration(KqlParser.LetFunctionDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitLetFunctionDeclaration(context);
    }

    public override string VisitLetViewDeclaration(KqlParser.LetViewDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitLetViewDeclaration(context);
    }

    public override string VisitLetViewParameterList(KqlParser.LetViewParameterListContext context)
    {
        var table = context.GetText();
        return base.VisitLetViewParameterList(context);
    }

    public override string VisitLetMaterializeDeclaration(KqlParser.LetMaterializeDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitLetMaterializeDeclaration(context);
    }

    public override string VisitLetEntityGroupDeclaration(KqlParser.LetEntityGroupDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitLetEntityGroupDeclaration(context);
    }

    public override string VisitLetFunctionParameterList(KqlParser.LetFunctionParameterListContext context)
    {
        var table = context.GetText();
        return base.VisitLetFunctionParameterList(context);
    }

    public override string VisitScalarParameter(KqlParser.ScalarParameterContext context)
    {
        var table = context.GetText();
        return base.VisitScalarParameter(context);
    }

    public override string VisitScalarParameterDefault(KqlParser.ScalarParameterDefaultContext context)
    {
        var table = context.GetText();
        return base.VisitScalarParameterDefault(context);
    }

    public override string VisitTabularParameter(KqlParser.TabularParameterContext context)
    {
        var table = context.GetText();
        return base.VisitTabularParameter(context);
    }

    public override string VisitTabularParameterOpenSchema(KqlParser.TabularParameterOpenSchemaContext context)
    {
        var table = context.GetText();
        return base.VisitTabularParameterOpenSchema(context);
    }

    public override string VisitTabularParameterRowSchema(KqlParser.TabularParameterRowSchemaContext context)
    {
        var table = context.GetText();
        return base.VisitTabularParameterRowSchema(context);
    }

    public override string VisitTabularParameterRowSchemaColumnDeclaration(KqlParser.TabularParameterRowSchemaColumnDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitTabularParameterRowSchemaColumnDeclaration(context);
    }

    public override string VisitLetFunctionBody(KqlParser.LetFunctionBodyContext context)
    {
        var table = context.GetText();
        return base.VisitLetFunctionBody(context);
    }

    public override string VisitLetFunctionBodyStatement(KqlParser.LetFunctionBodyStatementContext context)
    {
        var table = context.GetText();
        return base.VisitLetFunctionBodyStatement(context);
    }

    public override string VisitDeclarePatternStatement(KqlParser.DeclarePatternStatementContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternStatement(context);
    }

    public override string VisitDeclarePatternDefinition(KqlParser.DeclarePatternDefinitionContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternDefinition(context);
    }

    public override string VisitDeclarePatternParameterList(KqlParser.DeclarePatternParameterListContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternParameterList(context);
    }

    public override string VisitDeclarePatternParameter(KqlParser.DeclarePatternParameterContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternParameter(context);
    }

    public override string VisitDeclarePatternPathParameter(KqlParser.DeclarePatternPathParameterContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternPathParameter(context);
    }

    public override string VisitDeclarePatternRule(KqlParser.DeclarePatternRuleContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternRule(context);
    }

    public override string VisitDeclarePatternRuleArgumentList(KqlParser.DeclarePatternRuleArgumentListContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternRuleArgumentList(context);
    }

    public override string VisitDeclarePatternRulePathArgument(KqlParser.DeclarePatternRulePathArgumentContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternRulePathArgument(context);
    }

    public override string VisitDeclarePatternRuleArgument(KqlParser.DeclarePatternRuleArgumentContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternRuleArgument(context);
    }

    public override string VisitDeclarePatternBody(KqlParser.DeclarePatternBodyContext context)
    {
        var table = context.GetText();
        return base.VisitDeclarePatternBody(context);
    }

    public override string VisitRestrictAccessStatement(KqlParser.RestrictAccessStatementContext context)
    {
        var table = context.GetText();
        return base.VisitRestrictAccessStatement(context);
    }

    public override string VisitRestrictAccessStatementEntity(KqlParser.RestrictAccessStatementEntityContext context)
    {
        var table = context.GetText();
        return base.VisitRestrictAccessStatementEntity(context);
    }

    public override string VisitSetStatement(KqlParser.SetStatementContext context)
    {
        var table = context.GetText();
        return base.VisitSetStatement(context);
    }

    public override string VisitSetStatementOptionValue(KqlParser.SetStatementOptionValueContext context)
    {
        var table = context.GetText();
        return base.VisitSetStatementOptionValue(context);
    }

    public override string VisitDeclareQueryParametersStatement(KqlParser.DeclareQueryParametersStatementContext context)
    {
        var table = context.GetText();
        return base.VisitDeclareQueryParametersStatement(context);
    }

    public override string VisitDeclareQueryParametersStatementParameter(KqlParser.DeclareQueryParametersStatementParameterContext context)
    {
        var table = context.GetText();
        return base.VisitDeclareQueryParametersStatementParameter(context);
    }

    public override string VisitQueryStatement(KqlParser.QueryStatementContext context)
    {
        var table = context.GetText();
        return base.VisitQueryStatement(context);
    }

    public override string VisitExpression(KqlParser.ExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitExpression(context);
    }

    public override string VisitPipeExpression(KqlParser.PipeExpressionContext context)
    {
        // pods | where contains "etcd"
        var table = context.GetText();
        return base.VisitPipeExpression(context);
    }

    public override string VisitPipedOperator(KqlParser.PipedOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitPipedOperator(context);
    }

    public override string VisitPipeSubExpression(KqlParser.PipeSubExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitPipeSubExpression(context);
    }

    public override string VisitBeforePipeExpression(KqlParser.BeforePipeExpressionContext context)
    {
        var table = context.GetText();

        return base.VisitBeforePipeExpression(context);
    }

    public override string VisitAfterPipeOperator(KqlParser.AfterPipeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitAfterPipeOperator(context);
    }

    public override string VisitBeforeOrAfterPipeOperator(KqlParser.BeforeOrAfterPipeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitBeforeOrAfterPipeOperator(context);
    }

    public override string VisitForkPipeOperator(KqlParser.ForkPipeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitForkPipeOperator(context);
    }

    public override string VisitAsOperator(KqlParser.AsOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitAsOperator(context);
    }

    public override string VisitAssertSchemaOperator(KqlParser.AssertSchemaOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitAssertSchemaOperator(context);
    }

    public override string VisitConsumeOperator(KqlParser.ConsumeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitConsumeOperator(context);
    }

    public override string VisitCountOperator(KqlParser.CountOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitCountOperator(context);
    }

    public override string VisitCountOperatorAsClause(KqlParser.CountOperatorAsClauseContext context)
    {
        var table = context.GetText();
        return base.VisitCountOperatorAsClause(context);
    }

    public override string VisitDistinctOperator(KqlParser.DistinctOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitDistinctOperator(context);
    }

    public override string VisitDistinctOperatorStarTarget(KqlParser.DistinctOperatorStarTargetContext context)
    {
        var table = context.GetText();
        return base.VisitDistinctOperatorStarTarget(context);
    }

    public override string VisitDistinctOperatorColumnListTarget(KqlParser.DistinctOperatorColumnListTargetContext context)
    {
        var table = context.GetText();
        return base.VisitDistinctOperatorColumnListTarget(context);
    }

    public override string VisitEvaluateOperator(KqlParser.EvaluateOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitEvaluateOperator(context);
    }

    public override string VisitEvaluateOperatorSchemaClause(KqlParser.EvaluateOperatorSchemaClauseContext context)
    {
        var table = context.GetText();
        return base.VisitEvaluateOperatorSchemaClause(context);
    }

    public override string VisitUnionOperatorExpression(KqlParser.UnionOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitUnionOperatorExpression(context);
    }

    public override string VisitWhereOperator(KqlParser.WhereOperatorContext context)
    {
        var table = context.GetText();

        return base.VisitWhereOperator(context);
    }

    public override string VisitContextualSubExpression(KqlParser.ContextualSubExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitContextualSubExpression(context);
    }

    public override string VisitContextualPipeExpression(KqlParser.ContextualPipeExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitContextualPipeExpression(context);
    }

    public override string VisitContextualPipeExpressionPipedOperator(KqlParser.ContextualPipeExpressionPipedOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitContextualPipeExpressionPipedOperator(context);
    }

    public override string VisitStrictQueryOperatorParameter(KqlParser.StrictQueryOperatorParameterContext context)
    {
        var table = context.GetText();
        return base.VisitStrictQueryOperatorParameter(context);
    }

    public override string VisitRelaxedQueryOperatorParameter(KqlParser.RelaxedQueryOperatorParameterContext context)
    {
        var table = context.GetText();
        return base.VisitRelaxedQueryOperatorParameter(context);
    }

    public override string VisitQueryOperatorProperty(KqlParser.QueryOperatorPropertyContext context)
    {
        var table = context.GetText();
        return base.VisitQueryOperatorProperty(context);
    }

    public override string VisitNamedExpression(KqlParser.NamedExpressionContext context)
    {
        // named expression such as contains 'etcd'
        var table = context.GetText();
        return base.VisitNamedExpression(context);
    }

    public override string VisitNamedExpressionNameClause(KqlParser.NamedExpressionNameClauseContext context)
    {
        var table = context.GetText();
        return base.VisitNamedExpressionNameClause(context);
    }

    public override string VisitNamedExpressionNameList(KqlParser.NamedExpressionNameListContext context)
    {
        var table = context.GetText();
        return base.VisitNamedExpressionNameList(context);
    }

    public override string VisitScopedFunctionCallExpression(KqlParser.ScopedFunctionCallExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitScopedFunctionCallExpression(context);
    }

    public override string VisitUnnamedExpression(KqlParser.UnnamedExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitUnnamedExpression(context);
    }

    public override string VisitLogicalOrExpression(KqlParser.LogicalOrExpressionContext context)
    {
        // pods
        var table = context.GetText();
        return base.VisitLogicalOrExpression(context);
    }

    public override string VisitLogicalOrOperation(KqlParser.LogicalOrOperationContext context)
    {
        var table = context.GetText();
        return base.VisitLogicalOrOperation(context);
    }

    public override string VisitLogicalAndExpression(KqlParser.LogicalAndExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitLogicalAndExpression(context);
    }

    public override string VisitLogicalAndOperation(KqlParser.LogicalAndOperationContext context)
    {
        var table = context.GetText();
        return base.VisitLogicalAndOperation(context);
    }

    public override string VisitEqualityExpression(KqlParser.EqualityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitEqualityExpression(context);
    }

    public override string VisitEqualsEqualityExpression(KqlParser.EqualsEqualityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitEqualsEqualityExpression(context);
    }

    public override string VisitListEqualityExpression(KqlParser.ListEqualityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitListEqualityExpression(context);
    }

    public override string VisitBetweenEqualityExpression(KqlParser.BetweenEqualityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitBetweenEqualityExpression(context);
    }

    public override string VisitStarEqualityExpression(KqlParser.StarEqualityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitStarEqualityExpression(context);
    }

    public override string VisitRelationalExpression(KqlParser.RelationalExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitRelationalExpression(context);
    }


    public override string VisitAdditiveExpression(KqlParser.AdditiveExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitAdditiveExpression(context);
    }

    public override string VisitAdditiveOperation(KqlParser.AdditiveOperationContext context)
    {
        var table = context.GetText();
        return base.VisitAdditiveOperation(context);
    }

    public override string VisitMultiplicativeExpression(KqlParser.MultiplicativeExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitMultiplicativeExpression(context);
    }

    public override string VisitMultiplicativeOperation(KqlParser.MultiplicativeOperationContext context)
    {
        var table = context.GetText();
        return base.VisitMultiplicativeOperation(context);
    }

    public override string VisitStringOperatorExpression(KqlParser.StringOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitStringOperatorExpression(context);
    }

    public override string VisitStringBinaryOperatorExpression(KqlParser.StringBinaryOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitStringBinaryOperatorExpression(context);
    }

    public override string VisitStringBinaryOperation(KqlParser.StringBinaryOperationContext context)
    {
        var table = context.GetText();
        return base.VisitStringBinaryOperation(context);
    }

    public override string VisitStringBinaryOperator(KqlParser.StringBinaryOperatorContext context)
    {
        // this would ba "contains" in our sample
        var table = context.GetText();

        return base.VisitStringBinaryOperator(context);
    }

    public override string VisitStringStarOperatorExpression(KqlParser.StringStarOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitStringStarOperatorExpression(context);
    }

    public override string VisitInvocationExpression(KqlParser.InvocationExpressionContext context)
    {
        // in sample this is the text for contains
        var table = context.GetText();
        return base.VisitInvocationExpression(context);
    }

    public override string VisitFunctionCallOrPathExpression(KqlParser.FunctionCallOrPathExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionCallOrPathExpression(context);
    }

    public override string VisitFunctionCallOrPathRoot(KqlParser.FunctionCallOrPathRootContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionCallOrPathRoot(context);
    }

    public override string VisitFunctionCallOrPathPathExpression(KqlParser.FunctionCallOrPathPathExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionCallOrPathPathExpression(context);
    }

    public override string VisitFunctionCallOrPathOperation(KqlParser.FunctionCallOrPathOperationContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionCallOrPathOperation(context);
    }

    public override string VisitFunctionalCallOrPathPathOperation(KqlParser.FunctionalCallOrPathPathOperationContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionalCallOrPathPathOperation(context);
    }

    public override string VisitFunctionCallOrPathElementOperation(KqlParser.FunctionCallOrPathElementOperationContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionCallOrPathElementOperation(context);
    }

    public override string VisitLegacyFunctionCallOrPathElementOperation(KqlParser.LegacyFunctionCallOrPathElementOperationContext context)
    {
        var table = context.GetText();
        return base.VisitLegacyFunctionCallOrPathElementOperation(context);
    }

    public override string VisitToScalarExpression(KqlParser.ToScalarExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitToScalarExpression(context);
    }

    public override string VisitToTableExpression(KqlParser.ToTableExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitToTableExpression(context);
    }

    public override string VisitNoOptimizationParameter(KqlParser.NoOptimizationParameterContext context)
    {
        var table = context.GetText();
        return base.VisitNoOptimizationParameter(context);
    }

    public override string VisitDotCompositeFunctionCallExpression(KqlParser.DotCompositeFunctionCallExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitDotCompositeFunctionCallExpression(context);
    }

    public override string VisitDotCompositeFunctionCallOperation(KqlParser.DotCompositeFunctionCallOperationContext context)
    {
        var table = context.GetText();
        return base.VisitDotCompositeFunctionCallOperation(context);
    }

    public override string VisitFunctionCallExpression(KqlParser.FunctionCallExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFunctionCallExpression(context);
    }

    public override string VisitNamedFunctionCallExpression(KqlParser.NamedFunctionCallExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitNamedFunctionCallExpression(context);
    }

    public override string VisitArgumentExpression(KqlParser.ArgumentExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitArgumentExpression(context);
    }

    public override string VisitCountExpression(KqlParser.CountExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitCountExpression(context);
    }

    public override string VisitStarExpression(KqlParser.StarExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitStarExpression(context);
    }

    public override string VisitPrimaryExpression(KqlParser.PrimaryExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitPrimaryExpression(context);
    }

    public override string VisitNameReferenceWithDataScope(KqlParser.NameReferenceWithDataScopeContext context)
    {
        var table = context.GetText();
        return base.VisitNameReferenceWithDataScope(context);
    }

    public override string VisitDataScopeClause(KqlParser.DataScopeClauseContext context)
    {
        var table = context.GetText();
        return base.VisitDataScopeClause(context);
    }

    public override string VisitParenthesizedExpression(KqlParser.ParenthesizedExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitParenthesizedExpression(context);
    }

    public override string VisitRangeExpression(KqlParser.RangeExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitRangeExpression(context);
    }

    public override string VisitEntityExpression(KqlParser.EntityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitEntityExpression(context);
    }

    public override string VisitEntityPathOrElementExpression(KqlParser.EntityPathOrElementExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitEntityPathOrElementExpression(context);
    }

    public override string VisitEntityPathOrElementOperator(KqlParser.EntityPathOrElementOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitEntityPathOrElementOperator(context);
    }

    public override string VisitEntityPathOperator(KqlParser.EntityPathOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitEntityPathOperator(context);
    }

    public override string VisitEntityElementOperator(KqlParser.EntityElementOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitEntityElementOperator(context);
    }

    public override string VisitLegacyEntityPathElementOperator(KqlParser.LegacyEntityPathElementOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitLegacyEntityPathElementOperator(context);
    }

    public override string VisitEntityName(KqlParser.EntityNameContext context)
    {
        var table = context.GetText();
        return base.VisitEntityName(context);
    }

    public override string VisitEntityNameReference(KqlParser.EntityNameReferenceContext context)
    {
        var table = context.GetText();
        return base.VisitEntityNameReference(context);
    }

    public override string VisitAtSignName(KqlParser.AtSignNameContext context)
    {
        var table = context.GetText();
        return base.VisitAtSignName(context);
    }

    public override string VisitExtendedPathName(KqlParser.ExtendedPathNameContext context)
    {
        var table = context.GetText();
        return base.VisitExtendedPathName(context);
    }

    public override string VisitWildcardedEntityExpression(KqlParser.WildcardedEntityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedEntityExpression(context);
    }

    public override string VisitWildcardedPathExpression(KqlParser.WildcardedPathExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedPathExpression(context);
    }

    public override string VisitWildcardedPathName(KqlParser.WildcardedPathNameContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedPathName(context);
    }

    public override string VisitContextualDataTableExpression(KqlParser.ContextualDataTableExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitContextualDataTableExpression(context);
    }

    public override string VisitDataTableExpression(KqlParser.DataTableExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitDataTableExpression(context);
    }

    public override string VisitRowSchema(KqlParser.RowSchemaContext context)
    {
        var table = context.GetText();
        return base.VisitRowSchema(context);
    }

    public override string VisitRowSchemaColumnDeclaration(KqlParser.RowSchemaColumnDeclarationContext context)
    {
        var table = context.GetText();
        return base.VisitRowSchemaColumnDeclaration(context);
    }

    public override string VisitExternalDataExpression(KqlParser.ExternalDataExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitExternalDataExpression(context);
    }

    public override string VisitExternalDataWithClause(KqlParser.ExternalDataWithClauseContext context)
    {
        var table = context.GetText();
        return base.VisitExternalDataWithClause(context);
    }

    public override string VisitExternalDataWithClauseProperty(KqlParser.ExternalDataWithClausePropertyContext context)
    {
        var table = context.GetText();
        return base.VisitExternalDataWithClauseProperty(context);
    }

    public override string VisitMaterializedViewCombineExpression(KqlParser.MaterializedViewCombineExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitMaterializedViewCombineExpression(context);
    }

    public override string VisitMaterializeViewCombineBaseClause(KqlParser.MaterializeViewCombineBaseClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMaterializeViewCombineBaseClause(context);
    }

    public override string VisitMaterializedViewCombineDeltaClause(KqlParser.MaterializedViewCombineDeltaClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMaterializedViewCombineDeltaClause(context);
    }

    public override string VisitMaterializedViewCombineAggregationsClause(KqlParser.MaterializedViewCombineAggregationsClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMaterializedViewCombineAggregationsClause(context);
    }

    public override string VisitScalarType(KqlParser.ScalarTypeContext context)
    {
        var table = context.GetText();
        return base.VisitScalarType(context);
    }

    public override string VisitExtendedScalarType(KqlParser.ExtendedScalarTypeContext context)
    {
        var table = context.GetText();
        return base.VisitExtendedScalarType(context);
    }

    public override string VisitParameterName(KqlParser.ParameterNameContext context)
    {
        var table = context.GetText();
        return base.VisitParameterName(context);
    }

    public override string VisitSimpleNameReference(KqlParser.SimpleNameReferenceContext context)
    {
        var table = context.GetText();
        return base.VisitSimpleNameReference(context);
    }

    public override string VisitExtendedNameReference(KqlParser.ExtendedNameReferenceContext context)
    {
        var table = context.GetText();
        return base.VisitExtendedNameReference(context);
    }

    public override string VisitWildcardedNameReference(KqlParser.WildcardedNameReferenceContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedNameReference(context);
    }

    public override string VisitSimpleOrWildcardedNameReference(KqlParser.SimpleOrWildcardedNameReferenceContext context)
    {
        var table = context.GetText();
        return base.VisitSimpleOrWildcardedNameReference(context);
    }

    public override string VisitIdentifierName(KqlParser.IdentifierNameContext context)
    {
        var table = context.GetText();
        return base.VisitIdentifierName(context);
    }

    public override string VisitKeywordName(KqlParser.KeywordNameContext context)
    {
        var table = context.GetText();
        return base.VisitKeywordName(context);
    }

    public override string VisitExtendOperator(KqlParser.ExtendOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitExtendOperator(context);
    }

    public override string VisitExecuteAndCacheOperator(KqlParser.ExecuteAndCacheOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitExecuteAndCacheOperator(context);
    }

    public override string VisitFacetByOperator(KqlParser.FacetByOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitFacetByOperator(context);
    }

    public override string VisitFacetByOperatorWithOperatorClause(KqlParser.FacetByOperatorWithOperatorClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFacetByOperatorWithOperatorClause(context);
    }

    public override string VisitFacetByOperatorWithExpressionClause(KqlParser.FacetByOperatorWithExpressionClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFacetByOperatorWithExpressionClause(context);
    }

    public override string VisitFindOperator(KqlParser.FindOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperator(context);
    }

    public override string VisitFindOperatorParametersWhereClause(KqlParser.FindOperatorParametersWhereClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorParametersWhereClause(context);
    }

    public override string VisitFindOperatorInClause(KqlParser.FindOperatorInClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorInClause(context);
    }

    public override string VisitFindOperatorProjectClause(KqlParser.FindOperatorProjectClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorProjectClause(context);
    }

    public override string VisitFindOperatorProjectExpression(KqlParser.FindOperatorProjectExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorProjectExpression(context);
    }

    public override string VisitFindOperatorColumnExpression(KqlParser.FindOperatorColumnExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorColumnExpression(context);
    }

    public override string VisitFindOperatorOptionalColumnType(KqlParser.FindOperatorOptionalColumnTypeContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorOptionalColumnType(context);
    }

    public override string VisitFindOperatorPackExpression(KqlParser.FindOperatorPackExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorPackExpression(context);
    }

    public override string VisitFindOperatorProjectSmartClause(KqlParser.FindOperatorProjectSmartClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorProjectSmartClause(context);
    }

    public override string VisitFindOperatorProjectAwayClause(KqlParser.FindOperatorProjectAwayClauseContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorProjectAwayClause(context);
    }

    public override string VisitFindOperatorProjectAwayStar(KqlParser.FindOperatorProjectAwayStarContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorProjectAwayStar(context);
    }

    public override string VisitFindOperatorProjectAwayColumnList(KqlParser.FindOperatorProjectAwayColumnListContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorProjectAwayColumnList(context);
    }

    public override string VisitFindOperatorSource(KqlParser.FindOperatorSourceContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorSource(context);
    }

    public override string VisitFindOperatorSourceEntityExpression(KqlParser.FindOperatorSourceEntityExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitFindOperatorSourceEntityExpression(context);
    }

    public override string VisitForkOperator(KqlParser.ForkOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitForkOperator(context);
    }

    public override string VisitForkOperatorFork(KqlParser.ForkOperatorForkContext context)
    {
        var table = context.GetText();
        return base.VisitForkOperatorFork(context);
    }

    public override string VisitForkOperatorExpressionName(KqlParser.ForkOperatorExpressionNameContext context)
    {
        var table = context.GetText();
        return base.VisitForkOperatorExpressionName(context);
    }

    public override string VisitForkOperatorExpression(KqlParser.ForkOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitForkOperatorExpression(context);
    }

    public override string VisitForkOperatorPipedOperator(KqlParser.ForkOperatorPipedOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitForkOperatorPipedOperator(context);
    }

    public override string VisitGetSchemaOperator(KqlParser.GetSchemaOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitGetSchemaOperator(context);
    }

    public override string VisitGraphMarkComponentsOperator(KqlParser.GraphMarkComponentsOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMarkComponentsOperator(context);
    }

    public override string VisitGraphMatchOperator(KqlParser.GraphMatchOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchOperator(context);
    }

    public override string VisitGraphMatchPattern(KqlParser.GraphMatchPatternContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchPattern(context);
    }

    public override string VisitGraphMatchPatternNode(KqlParser.GraphMatchPatternNodeContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchPatternNode(context);
    }

    public override string VisitGraphMatchPatternUnnamedEdge(KqlParser.GraphMatchPatternUnnamedEdgeContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchPatternUnnamedEdge(context);
    }

    public override string VisitGraphMatchPatternNamedEdge(KqlParser.GraphMatchPatternNamedEdgeContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchPatternNamedEdge(context);
    }

    public override string VisitGraphMatchPatternRange(KqlParser.GraphMatchPatternRangeContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchPatternRange(context);
    }

    public override string VisitGraphMatchWhereClause(KqlParser.GraphMatchWhereClauseContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchWhereClause(context);
    }

    public override string VisitGraphMatchProjectClause(KqlParser.GraphMatchProjectClauseContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMatchProjectClause(context);
    }

    public override string VisitGraphMergeOperator(KqlParser.GraphMergeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitGraphMergeOperator(context);
    }

    public override string VisitGraphToTableOperator(KqlParser.GraphToTableOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitGraphToTableOperator(context);
    }

    public override string VisitGraphToTableOutput(KqlParser.GraphToTableOutputContext context)
    {
        var table = context.GetText();
        return base.VisitGraphToTableOutput(context);
    }

    public override string VisitGraphToTableAsClause(KqlParser.GraphToTableAsClauseContext context)
    {
        var table = context.GetText();
        return base.VisitGraphToTableAsClause(context);
    }

    public override string VisitGraphShortestPathsOperator(KqlParser.GraphShortestPathsOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitGraphShortestPathsOperator(context);
    }

    public override string VisitInvokeOperator(KqlParser.InvokeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitInvokeOperator(context);
    }

    public override string VisitJoinOperator(KqlParser.JoinOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitJoinOperator(context);
    }

    public override string VisitJoinOperatorOnClause(KqlParser.JoinOperatorOnClauseContext context)
    {
        var table = context.GetText();
        return base.VisitJoinOperatorOnClause(context);
    }

    public override string VisitJoinOperatorWhereClause(KqlParser.JoinOperatorWhereClauseContext context)
    {
        var table = context.GetText();
        return base.VisitJoinOperatorWhereClause(context);
    }

    public override string VisitLookupOperator(KqlParser.LookupOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitLookupOperator(context);
    }

    public override string VisitMacroExpandOperator(KqlParser.MacroExpandOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitMacroExpandOperator(context);
    }

    public override string VisitMacroExpandEntityGroup(KqlParser.MacroExpandEntityGroupContext context)
    {
        var table = context.GetText();
        return base.VisitMacroExpandEntityGroup(context);
    }

    public override string VisitEntityGroupExpression(KqlParser.EntityGroupExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitEntityGroupExpression(context);
    }

    public override string VisitMakeGraphOperator(KqlParser.MakeGraphOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitMakeGraphOperator(context);
    }

    public override string VisitMakeGraphIdClause(KqlParser.MakeGraphIdClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeGraphIdClause(context);
    }

    public override string VisitMakeGraphTablesAndKeysClause(KqlParser.MakeGraphTablesAndKeysClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeGraphTablesAndKeysClause(context);
    }

    public override string VisitMakeGraphPartitionedByClause(KqlParser.MakeGraphPartitionedByClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeGraphPartitionedByClause(context);
    }

    public override string VisitMakeSeriesOperator(KqlParser.MakeSeriesOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperator(context);
    }

    public override string VisitMakeSeriesOperatorOnClause(KqlParser.MakeSeriesOperatorOnClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperatorOnClause(context);
    }

    public override string VisitMakeSeriesOperatorAggregation(KqlParser.MakeSeriesOperatorAggregationContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperatorAggregation(context);
    }

    public override string VisitMakeSeriesOperatorExpressionDefaultClause(KqlParser.MakeSeriesOperatorExpressionDefaultClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperatorExpressionDefaultClause(context);
    }

    public override string VisitMakeSeriesOperatorInRangeClause(KqlParser.MakeSeriesOperatorInRangeClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperatorInRangeClause(context);
    }

    public override string VisitMakeSeriesOperatorFromToStepClause(KqlParser.MakeSeriesOperatorFromToStepClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperatorFromToStepClause(context);
    }

    public override string VisitMakeSeriesOperatorByClause(KqlParser.MakeSeriesOperatorByClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMakeSeriesOperatorByClause(context);
    }

    public override string VisitMvapplyOperator(KqlParser.MvapplyOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitMvapplyOperator(context);
    }

    public override string VisitMvapplyOperatorLimitClause(KqlParser.MvapplyOperatorLimitClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMvapplyOperatorLimitClause(context);
    }

    public override string VisitMvapplyOperatorIdClause(KqlParser.MvapplyOperatorIdClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMvapplyOperatorIdClause(context);
    }

    public override string VisitMvapplyOperatorExpression(KqlParser.MvapplyOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitMvapplyOperatorExpression(context);
    }

    public override string VisitMvapplyOperatorExpressionToClause(KqlParser.MvapplyOperatorExpressionToClauseContext context)
    {
        var table = context.GetText();
        return base.VisitMvapplyOperatorExpressionToClause(context);
    }

    public override string VisitMvexpandOperator(KqlParser.MvexpandOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitMvexpandOperator(context);
    }

    public override string VisitMvexpandOperatorExpression(KqlParser.MvexpandOperatorExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitMvexpandOperatorExpression(context);
    }

    public override string VisitParseOperator(KqlParser.ParseOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitParseOperator(context);
    }

    public override string VisitParseOperatorKindClause(KqlParser.ParseOperatorKindClauseContext context)
    {
        var table = context.GetText();
        return base.VisitParseOperatorKindClause(context);
    }

    public override string VisitParseOperatorFlagsClause(KqlParser.ParseOperatorFlagsClauseContext context)
    {
        var table = context.GetText();
        return base.VisitParseOperatorFlagsClause(context);
    }

    public override string VisitParseOperatorNameAndOptionalType(KqlParser.ParseOperatorNameAndOptionalTypeContext context)
    {
        var table = context.GetText();
        return base.VisitParseOperatorNameAndOptionalType(context);
    }

    public override string VisitParseOperatorPattern(KqlParser.ParseOperatorPatternContext context)
    {
        var table = context.GetText();
        return base.VisitParseOperatorPattern(context);
    }

    public override string VisitParseOperatorPatternSegment(KqlParser.ParseOperatorPatternSegmentContext context)
    {
        var table = context.GetText();
        return base.VisitParseOperatorPatternSegment(context);
    }

    public override string VisitParseWhereOperator(KqlParser.ParseWhereOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitParseWhereOperator(context);
    }

    public override string VisitParseKvOperator(KqlParser.ParseKvOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitParseKvOperator(context);
    }

    public override string VisitParseKvWithClause(KqlParser.ParseKvWithClauseContext context)
    {
        var table = context.GetText();
        return base.VisitParseKvWithClause(context);
    }

    public override string VisitPartitionOperator(KqlParser.PartitionOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitPartitionOperator(context);
    }

    public override string VisitPartitionOperatorInClause(KqlParser.PartitionOperatorInClauseContext context)
    {
        var table = context.GetText();
        return base.VisitPartitionOperatorInClause(context);
    }

    public override string VisitPartitionOperatorSubExpressionBody(KqlParser.PartitionOperatorSubExpressionBodyContext context)
    {
        var table = context.GetText();
        return base.VisitPartitionOperatorSubExpressionBody(context);
    }

    public override string VisitPartitionOperatorFullExpressionBody(KqlParser.PartitionOperatorFullExpressionBodyContext context)
    {
        var table = context.GetText();
        return base.VisitPartitionOperatorFullExpressionBody(context);
    }

    public override string VisitPartitionByOperator(KqlParser.PartitionByOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitPartitionByOperator(context);
    }

    public override string VisitPartitionByOperatorIdClause(KqlParser.PartitionByOperatorIdClauseContext context)
    {
        var table = context.GetText();
        return base.VisitPartitionByOperatorIdClause(context);
    }

    public override string VisitPrintOperator(KqlParser.PrintOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitPrintOperator(context);
    }

    public override string VisitProjectAwayOperator(KqlParser.ProjectAwayOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitProjectAwayOperator(context);
    }

    public override string VisitProjectKeepOperator(KqlParser.ProjectKeepOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitProjectKeepOperator(context);
    }

    public override string VisitProjectOperator(KqlParser.ProjectOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitProjectOperator(context);
    }

    public override string VisitProjectRenameOperator(KqlParser.ProjectRenameOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitProjectRenameOperator(context);
    }

    public override string VisitProjectReorderOperator(KqlParser.ProjectReorderOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitProjectReorderOperator(context);
    }

    public override string VisitProjectReorderExpression(KqlParser.ProjectReorderExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitProjectReorderExpression(context);
    }

    public override string VisitReduceByOperator(KqlParser.ReduceByOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitReduceByOperator(context);
    }

    public override string VisitReduceByWithClause(KqlParser.ReduceByWithClauseContext context)
    {
        var table = context.GetText();
        return base.VisitReduceByWithClause(context);
    }

    public override string VisitRenderOperator(KqlParser.RenderOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitRenderOperator(context);
    }

    public override string VisitRenderOperatorWithClause(KqlParser.RenderOperatorWithClauseContext context)
    {
        var table = context.GetText();
        return base.VisitRenderOperatorWithClause(context);
    }

    public override string VisitRenderOperatorLegacyPropertyList(KqlParser.RenderOperatorLegacyPropertyListContext context)
    {
        var table = context.GetText();
        return base.VisitRenderOperatorLegacyPropertyList(context);
    }

    public override string VisitRenderOperatorProperty(KqlParser.RenderOperatorPropertyContext context)
    {
        var table = context.GetText();
        return base.VisitRenderOperatorProperty(context);
    }

    public override string VisitRenderPropertyNameList(KqlParser.RenderPropertyNameListContext context)
    {
        var table = context.GetText();
        return base.VisitRenderPropertyNameList(context);
    }

    public override string VisitRenderOperatorLegacyProperty(KqlParser.RenderOperatorLegacyPropertyContext context)
    {
        var table = context.GetText();
        return base.VisitRenderOperatorLegacyProperty(context);
    }

    public override string VisitSampleDistinctOperator(KqlParser.SampleDistinctOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitSampleDistinctOperator(context);
    }

    public override string VisitSampleOperator(KqlParser.SampleOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitSampleOperator(context);
    }

    public override string VisitScanOperator(KqlParser.ScanOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperator(context);
    }

    public override string VisitScanOperatorOrderByClause(KqlParser.ScanOperatorOrderByClauseContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorOrderByClause(context);
    }

    public override string VisitScanOperatorPartitionByClause(KqlParser.ScanOperatorPartitionByClauseContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorPartitionByClause(context);
    }

    public override string VisitScanOperatorDeclareClause(KqlParser.ScanOperatorDeclareClauseContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorDeclareClause(context);
    }

    public override string VisitScanOperatorStep(KqlParser.ScanOperatorStepContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorStep(context);
    }

    public override string VisitScanOperatorStepOutputClause(KqlParser.ScanOperatorStepOutputClauseContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorStepOutputClause(context);
    }

    public override string VisitScanOperatorBody(KqlParser.ScanOperatorBodyContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorBody(context);
    }

    public override string VisitScanOperatorAssignment(KqlParser.ScanOperatorAssignmentContext context)
    {
        var table = context.GetText();
        return base.VisitScanOperatorAssignment(context);
    }

    public override string VisitSearchOperator(KqlParser.SearchOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitSearchOperator(context);
    }

    public override string VisitSearchOperatorStarAndExpression(KqlParser.SearchOperatorStarAndExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitSearchOperatorStarAndExpression(context);
    }

    public override string VisitSearchOperatorInClause(KqlParser.SearchOperatorInClauseContext context)
    {
        var table = context.GetText();
        return base.VisitSearchOperatorInClause(context);
    }

    public override string VisitSerializeOperator(KqlParser.SerializeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitSerializeOperator(context);
    }

    public override string VisitSortOperator(KqlParser.SortOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitSortOperator(context);
    }

    public override string VisitOrderedExpression(KqlParser.OrderedExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitOrderedExpression(context);
    }

    public override string VisitSortOrdering(KqlParser.SortOrderingContext context)
    {
        var table = context.GetText();
        return base.VisitSortOrdering(context);
    }

    public override string VisitSummarizeOperator(KqlParser.SummarizeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitSummarizeOperator(context);
    }

    public override string VisitSummarizeOperatorByClause(KqlParser.SummarizeOperatorByClauseContext context)
    {
        var table = context.GetText();
        return base.VisitSummarizeOperatorByClause(context);
    }

    public override string VisitSummarizeOperatorLegacyBinClause(KqlParser.SummarizeOperatorLegacyBinClauseContext context)
    {
        var table = context.GetText();
        return base.VisitSummarizeOperatorLegacyBinClause(context);
    }

    public override string VisitTakeOperator(KqlParser.TakeOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitTakeOperator(context);
    }

    public override string VisitTopOperator(KqlParser.TopOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitTopOperator(context);
    }

    public override string VisitTopHittersOperator(KqlParser.TopHittersOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitTopHittersOperator(context);
    }

    public override string VisitTopHittersOperatorByClause(KqlParser.TopHittersOperatorByClauseContext context)
    {
        var table = context.GetText();
        return base.VisitTopHittersOperatorByClause(context);
    }

    public override string VisitTopNestedOperator(KqlParser.TopNestedOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitTopNestedOperator(context);
    }

    public override string VisitTopNestedOperatorPart(KqlParser.TopNestedOperatorPartContext context)
    {
        var table = context.GetText();
        return base.VisitTopNestedOperatorPart(context);
    }

    public override string VisitTopNestedOperatorWithOthersClause(KqlParser.TopNestedOperatorWithOthersClauseContext context)
    {
        var table = context.GetText();
        return base.VisitTopNestedOperatorWithOthersClause(context);
    }

    public override string VisitUnionOperator(KqlParser.UnionOperatorContext context)
    {
        var table = context.GetText();
        return base.VisitUnionOperator(context);
    }

    public override string VisitExtendedKeywordName(KqlParser.ExtendedKeywordNameContext context)
    {
        var table = context.GetText();
        return base.VisitExtendedKeywordName(context);
    }

    public override string VisitEscapedName(KqlParser.EscapedNameContext context)
    {
        var table = context.GetText();
        return base.VisitEscapedName(context);
    }

    public override string VisitIdentifierOrKeywordName(KqlParser.IdentifierOrKeywordNameContext context)
    {
        var table = context.GetText();
        return base.VisitIdentifierOrKeywordName(context);
    }

    public override string VisitIdentifierOrKeywordOrEscapedName(KqlParser.IdentifierOrKeywordOrEscapedNameContext context)
    {
        var table = context.GetText();
        return base.VisitIdentifierOrKeywordOrEscapedName(context);
    }

    public override string VisitIdentifierOrExtendedKeywordOrEscapedName(KqlParser.IdentifierOrExtendedKeywordOrEscapedNameContext context)
    {
        var table = context.GetText();
        return base.VisitIdentifierOrExtendedKeywordOrEscapedName(context);
    }

    public override string VisitIdentifierOrExtendedKeywordName(KqlParser.IdentifierOrExtendedKeywordNameContext context)
    {
        var table = context.GetText();
        return base.VisitIdentifierOrExtendedKeywordName(context);
    }

    public override string VisitWildcardedName(KqlParser.WildcardedNameContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedName(context);
    }

    public override string VisitWildcardedNamePrefix(KqlParser.WildcardedNamePrefixContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedNamePrefix(context);
    }

    public override string VisitWildcardedNameSegment(KqlParser.WildcardedNameSegmentContext context)
    {
        var table = context.GetText();
        return base.VisitWildcardedNameSegment(context);
    }

    public override string VisitLiteralExpression(KqlParser.LiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitLiteralExpression(context);
    }

    public override string VisitUnsignedLiteralExpression(KqlParser.UnsignedLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitUnsignedLiteralExpression(context);
    }

    public override string VisitNumberLikeLiteralExpression(KqlParser.NumberLikeLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitNumberLikeLiteralExpression(context);
    }

    public override string VisitNumericLiteralExpression(KqlParser.NumericLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitNumericLiteralExpression(context);
    }

    public override string VisitSignedLiteralExpression(KqlParser.SignedLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitSignedLiteralExpression(context);
    }

    public override string VisitLongLiteralExpression(KqlParser.LongLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitLongLiteralExpression(context);
    }

    public override string VisitIntLiteralExpression(KqlParser.IntLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitIntLiteralExpression(context);
    }

    public override string VisitRealLiteralExpression(KqlParser.RealLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitRealLiteralExpression(context);
    }

    public override string VisitDecimalLiteralExpression(KqlParser.DecimalLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitDecimalLiteralExpression(context);
    }

    public override string VisitDateTimeLiteralExpression(KqlParser.DateTimeLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitDateTimeLiteralExpression(context);
    }

    public override string VisitTimeSpanLiteralExpression(KqlParser.TimeSpanLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitTimeSpanLiteralExpression(context);
    }

    public override string VisitBooleanLiteralExpression(KqlParser.BooleanLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitBooleanLiteralExpression(context);
    }

    public override string VisitGuidLiteralExpression(KqlParser.GuidLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitGuidLiteralExpression(context);
    }

    public override string VisitTypeLiteralExpression(KqlParser.TypeLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitTypeLiteralExpression(context);
    }

    public override string VisitSignedLongLiteralExpression(KqlParser.SignedLongLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitSignedLongLiteralExpression(context);
    }

    public override string VisitSignedRealLiteralExpression(KqlParser.SignedRealLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitSignedRealLiteralExpression(context);
    }

    public override string VisitStringLiteralExpression(KqlParser.StringLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitStringLiteralExpression(context);
    }

    public override string VisitDynamicLiteralExpression(KqlParser.DynamicLiteralExpressionContext context)
    {
        var table = context.GetText();
        return base.VisitDynamicLiteralExpression(context);
    }

    public override string VisitJsonValue(KqlParser.JsonValueContext context)
    {
        var table = context.GetText();
        return base.VisitJsonValue(context);
    }

    public override string VisitJsonObject(KqlParser.JsonObjectContext context)
    {
        var table = context.GetText();
        return base.VisitJsonObject(context);
    }

    public override string VisitJsonPair(KqlParser.JsonPairContext context)
    {
        var table = context.GetText();
        return base.VisitJsonPair(context);
    }

    public override string VisitJsonArray(KqlParser.JsonArrayContext context)
    {
        var table = context.GetText();
        return base.VisitJsonArray(context);
    }

    public override string VisitJsonBoolean(KqlParser.JsonBooleanContext context)
    {
        var table = context.GetText();
        return base.VisitJsonBoolean(context);
    }

    public override string VisitJsonDateTime(KqlParser.JsonDateTimeContext context)
    {
        var table = context.GetText();
        return base.VisitJsonDateTime(context);
    }

    public override string VisitJsonGuid(KqlParser.JsonGuidContext context)
    {
        var table = context.GetText();
        return base.VisitJsonGuid(context);
    }

    public override string VisitJsonNull(KqlParser.JsonNullContext context)
    {
        var table = context.GetText();
        return base.VisitJsonNull(context);
    }

    public override string VisitJsonString(KqlParser.JsonStringContext context)
    {
        var table = context.GetText();
        return base.VisitJsonString(context);
    }

    public override string VisitJsonTimeSpan(KqlParser.JsonTimeSpanContext context)
    {
        var table = context.GetText();
        return base.VisitJsonTimeSpan(context);
    }

    public override string VisitJsonLong(KqlParser.JsonLongContext context)
    {
        var table = context.GetText();
        return base.VisitJsonLong(context);
    }

    public override string VisitJsonReal(KqlParser.JsonRealContext context)
    {
        var table = context.GetText();
        return base.VisitJsonReal(context);
    }

    public override string Visit(IParseTree tree)
    {
        return base.Visit(tree);
    }

    public override string VisitChildren(IRuleNode node)
    {
        return base.VisitChildren(node);
    }

    public override string VisitTerminal(ITerminalNode node)
    {
        return base.VisitTerminal(node);
    }

    public override string VisitErrorNode(IErrorNode node)
    {
        return base.VisitErrorNode(node);
    }
}
