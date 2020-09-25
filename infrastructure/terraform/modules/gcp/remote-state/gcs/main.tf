resource "google_storage_bucket" "remote-state" {
  name          = var.bucket_name
  force_destroy = true
  versioning {
    enabled = true
  }
  bucket_policy_only = true
}
