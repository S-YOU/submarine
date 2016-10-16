// This file was generated by typhen-api

package submarine

import (
	"errors"
	"fmt"
	"github.com/shiwano/submarine/server/battle/lib/typhenapi/core"
	"net/url"
)

var _ = errors.New

type GetRoomsRequestBody struct {
}

// Coerce the fields.
func (t *GetRoomsRequestBody) Coerce() error {
	return nil
}

// Bytes creates the byte array.
func (t *GetRoomsRequestBody) Bytes(serializer typhenapi.Serializer) ([]byte, error) {
	if err := t.Coerce(); err != nil {
		return nil, err
	}

	data, err := serializer.Serialize(t)
	if err != nil {
		return nil, err
	}

	return data, nil
}

// QueryString returns the query string.
func (t *GetRoomsRequestBody) QueryString() string {
	queryString := fmt.Sprintf("")
	return url.QueryEscape(queryString)
}