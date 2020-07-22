﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;

using Microsoft.Templates.Core;
using Microsoft.TemplateEngine.Abstractions;

using Xunit;
using Microsoft.Templates.Core.Extensions;

namespace Microsoft.Templates.Test.Build.Uwp
{
    [Collection("BuildTemplateTestCollection")]
    public class BuildCodeBehindProjectTests : BaseGenAndBuildTests
    {
        public BuildCodeBehindProjectTests(BuildTemplatesTestFixture fixture)
            : base(fixture, null, "CodeBehind")
        {
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetProjectTemplatesForBuild), "CodeBehind", "", Platforms.Uwp)]
        [Trait("ExecutionSet", "BuildCodeBehind")]
        [Trait("ExecutionSet", "_Full")]
        [Trait("Type", "BuildProjects")]
        public async Task Build_EmptyProject_InferConfig_UwpAsync(string projectType, string framework, string platform, string language)
        {
            var (projectName, projectPath) = await GenerateEmptyProjectAsync(projectType, framework, platform, language);

            // Don't delete after build test as used in inference test, which will then delete.
            AssertBuildProject(projectPath, projectName, platform, deleteAfterBuild: false);

            EnsureCanInferConfigInfo(projectType, framework, platform, projectPath);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetProjectTemplatesForBuild), "CodeBehind", "", Platforms.Uwp)]
        [Trait("ExecutionSet", "BuildCodeBehind")]
        [Trait("ExecutionSet", "_Full")]
        [Trait("Type", "BuildAllPagesAndFeatures")]
        [Trait("Type", "BuildRandomNames")]
        public async Task Build_All_ProjectNameValidation_G1_UwpAsync(string projectType, string framework, string platform, string language)
        {
            bool templateSelector(ITemplateInfo t) => t.GetTemplateType().IsItemTemplate()
                && (t.GetProjectTypeList().Contains(projectType) || t.GetProjectTypeList().Contains(All))
                && (t.GetFrontEndFrameworkList().Contains(framework) || t.GetFrontEndFrameworkList().Contains(All))
                && t.GetPlatform() == platform
                && !excludedTemplates_Uwp_Group2.Contains(t.GroupIdentity)
                && !excludedTemplatesGroup2VB.Contains(t.GroupIdentity)
                && !t.GetIsHidden();

            var projectName = $"{(projectType)}{CharactersThatMayCauseProjectNameIssues()}G1{ShortLanguageName(language)}";

            var projectPath = await AssertGenerateProjectAsync(projectName, projectType, framework, platform, language, templateSelector, BaseGenAndBuildFixture.GetRandomName);

            AssertBuildProject(projectPath, projectName, platform);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetProjectTemplatesForBuild), "CodeBehind", "", Platforms.Uwp)]
        [Trait("ExecutionSet", "BuildCodeBehind")]
        [Trait("ExecutionSet", "_Full")]
        [Trait("Type", "BuildAllPagesAndFeatures")]
        [Trait("Type", "BuildRandomNames")]
        public async Task Build_All_ProjectNameValidation_G2_UwpAsync(string projectType, string framework, string platform, string language)
        {
            bool templateSelector(ITemplateInfo t) => t.GetTemplateType().IsItemTemplate()
                && (t.GetProjectTypeList().Contains(projectType) || t.GetProjectTypeList().Contains(All))
                && (t.GetFrontEndFrameworkList().Contains(framework) || t.GetFrontEndFrameworkList().Contains(All))
                && t.GetPlatform() == platform
                && !excludedTemplates_Uwp_Group1.Contains(t.GroupIdentity)
                && !excludedTemplatesGroup1VB.Contains(t.GroupIdentity)
                && !t.GetIsHidden();

            var projectName = $"{ShortProjectType(projectType)}{CharactersThatMayCauseProjectNameIssues()}G2{ShortLanguageName(language)}";

            var projectPath = await AssertGenerateProjectAsync(projectName, projectType, framework, platform, language, templateSelector, BaseGenAndBuildFixture.GetRandomName);

            AssertBuildProject(projectPath, projectName, platform);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetProjectTemplatesForBuild), "CodeBehind", ProgrammingLanguages.CSharp, Platforms.Uwp)]
        [Trait("ExecutionSet", "Minimum")]
        [Trait("ExecutionSet", "MinimumCodeBehind")]
        [Trait("ExecutionSet", "_CIBuild")]
        [Trait("ExecutionSet", "_Full")]
        [Trait("Type", "CodeStyle")]
        public async Task BuildAndTest_All_CheckWithStyleCop_G2_UwpAsync(string projectType, string framework, string platform, string language)
        {
            bool templateSelector(ITemplateInfo t) => t.GetTemplateType().IsItemTemplate()
                && (t.GetProjectTypeList().Contains(projectType) || t.GetProjectTypeList().Contains(All))
                && (t.GetFrontEndFrameworkList().Contains(framework) || t.GetFrontEndFrameworkList().Contains(All))
                && t.GetPlatform() == platform
                && !t.GetIsHidden()
                && !excludedTemplates_Uwp_Group1.Contains(t.GroupIdentity)
                || t.Identity == "wts.Feat.StyleCop";

            var projectName = $"{projectType}{framework}AllStyleCopG2";

            var projectPath = await AssertGenerateProjectAsync(projectName, projectType, framework, platform, language, templateSelector, BaseGenAndBuildFixture.GetDefaultName, true);

            AssertBuildProjectThenRunTests(projectPath, projectName, platform);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetProjectTemplatesForBuild), "CodeBehind", ProgrammingLanguages.CSharp, Platforms.Uwp)]
        [Trait("ExecutionSet", "Minimum")]
        [Trait("ExecutionSet", "BuildCodeBehind")]
        [Trait("ExecutionSet", "_Full")]
        [Trait("Type", "CodeStyle")]
        public async Task BuildAndTest_All_CheckWithStyleCop_G1_UwpAsync(string projectType, string framework, string platform, string language)
        {
            bool templateSelector(ITemplateInfo t) => t.GetTemplateType().IsItemTemplate()
                && (t.GetProjectTypeList().Contains(projectType) || t.GetProjectTypeList().Contains(All))
                && (t.GetFrontEndFrameworkList().Contains(framework) || t.GetFrontEndFrameworkList().Contains(All))
                && t.GetPlatform() == platform
                && !t.GetIsHidden()
                && !excludedTemplates_Uwp_Group2.Contains(t.GroupIdentity)
                || t.Identity == "wts.Feat.StyleCop";

            var projectName = $"{projectType}{framework}AllStyleCopG1";

            var projectPath = await AssertGenerateProjectAsync(projectName, projectType, framework, platform, language, templateSelector, BaseGenAndBuildFixture.GetDefaultName, false);

            AssertBuildProjectThenRunTests(projectPath, projectName, platform);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetProjectTemplatesForBuild), "CodeBehind", "", Platforms.Uwp)]
        [Trait("ExecutionSet", "BuildCodeBehind")]
        [Trait("ExecutionSet", "_Full")]
        [Trait("Type", "BuildRightClick")]
        public async Task Build_Empty_AddRightClick_UwpAsync(string projectType, string framework, string platform, string language)
        {
            var projectName = $"{ShortProjectType(projectType)}AllR{ShortLanguageName(language)}";

            var projectPath = await AssertGenerateRightClickAsync(projectName, projectType, framework, platform, language, true);

            AssertBuildProject(projectPath, projectName, platform);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetPageAndFeatureTemplatesForBuild), "CodeBehind", ProgrammingLanguages.CSharp, Platforms.Uwp, "")]
        [Trait("ExecutionSet", "BuildOneByOneCodeBehind")]
        [Trait("ExecutionSet", "_OneByOne")]
        [Trait("Type", "BuildOneByOneCodeBehind")]
        public async Task Build_CodeBehind_CS_OneByOneItems_UwpAsync(string itemName, string projectType, string framework, string platform, string itemId, string language)
        {
            var (ProjectPath, ProjecName) = await AssertGenerationOneByOneAsync(itemName, projectType, framework, platform, itemId, language, false);

            AssertBuildProject(ProjectPath, ProjecName, platform);
        }

        [Theory]
        [MemberData(nameof(BaseGenAndBuildTests.GetPageAndFeatureTemplatesForBuild), "CodeBehind", ProgrammingLanguages.VisualBasic, Platforms.Uwp, "")]
        [Trait("ExecutionSet", "BuildOneByOneCodeBehind")]
        [Trait("ExecutionSet", "_OneByOne")]
        [Trait("Type", "BuildOneByOneCodeBehind")]
        public async Task Build_CodeBehind_VB_OneByOneItems_UwpAsync(string itemName, string projectType, string framework, string platform, string itemId, string language)
        {
            var (ProjectPath, ProjecName) = await AssertGenerationOneByOneAsync(itemName, projectType, framework, platform, itemId, language, false);

            AssertBuildProject(ProjectPath, ProjecName, platform);
        }

       
    }
}