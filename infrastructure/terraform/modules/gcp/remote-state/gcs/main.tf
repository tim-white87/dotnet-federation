resource "google_storage_bucket" "remote-state" {
  name          = "dotnet-federation-remote-state"
  force_destroy = true
  versioning {
    enabled = true
  }
  bucket_policy_only = true
}
