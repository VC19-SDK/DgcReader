﻿using Newtonsoft.Json;
using System;

namespace DgcReader.RuleValidators.Italy.Models;

internal class GitHubReleaseInfo
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("url")] public string? Url { get; set; }
    [JsonProperty("assets_url")] public string? AssetsUrl { get; set; }
    [JsonProperty("upload_url")] public string? UploadUrl { get; set; }
    [JsonProperty("html_url")] public string? HtmlUrl { get; set; }
    [JsonProperty("node_id")] public string? NodeId { get; set; }
    [JsonProperty("tag_name")] public string? TagName { get; set; }
    [JsonProperty("target_commitish")] public string? TargetCommitish { get; set; }
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("draft")] public bool Draft { get; set; }
    [JsonProperty("prerelease")] public bool Prerelease { get; set; }
    [JsonProperty("created_at")] public DateTime? CreatedAt { get; set; }
    [JsonProperty("published_at")] public DateTime? PublishedAt { get; set; }
    [JsonProperty("tarball_url")] public string? TarballUrl { get; set; }
    [JsonProperty("zipball_url")] public string? ZipballUrl { get; set; }
    [JsonProperty("body")] public string? Body { get; set; }
}